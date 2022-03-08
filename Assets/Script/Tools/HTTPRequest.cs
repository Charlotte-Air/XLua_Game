using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
/// <summary>
/// Http请求
/// </summary>
public class HTTPRequest
{
    private string url;
    private int timeout;
    private Action<HTTPResponse> callback;
    private HttpWebRequest request;
    private string method;
    private string contentType;
    private KeyValuePair<string, int> proxy;
    protected int range = -1;
    // post内容
    private StringBuilder postBuilder;
    /// <summary>
    /// 错误代码
    /// </summary>
    public const int ERR_EXCEPTION = -1;
    /// <summary>
    /// 构造函数, 构造GET请求
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="timeout">超时时间</param>
    /// <param name="callback">回调函数</param>
    public HTTPRequest(string url, string method, int timeout, Action<HTTPResponse> callback)
    {
        this.url = url;
        this.timeout = timeout;
        this.callback = callback;
        this.method = method.ToUpper();
    }
    /// <summary>
    /// 设置Post内容
    /// </summary>
    /// <param name="data">内容</param>
    public void SetPostData(string data)
    {
        if (postBuilder == null)
        {
            postBuilder = new StringBuilder(data.Length);
        }
        if (postBuilder.Length > 0)
        {
            postBuilder.Append("&");
        }
        postBuilder.Append(data);
    }
    /// <summary>
    /// 添加Post内容
    /// </summary>
    /// <param name="key">key值</param>
    /// <param name="value">value值</param>
    public void AddPostData(string key, string value)
    {
        if (postBuilder == null)
        {
            postBuilder = new StringBuilder();
        }
        if (postBuilder.Length > 0)
        {
            postBuilder.Append("&");
        }
        postBuilder.Append(key).Append("=").Append(value);
    }
    /// <summary>
    /// 设置代理
    /// </summary>
    /// <param name="ip">ip地址</param>
    /// <param name="port">端口号</param>
    public void SetProxy(string ip, int port)
    {
        this.proxy = new KeyValuePair<string, int>(ip, port);
    }
    /// <summary>
    /// 设置ContentType
    /// </summary>
    /// <value>ContentType value</value>
    public string ContentType
    {
        set
        {
            this.contentType = value;
        }
    }
    /// <summary>
    /// 发动请求
    /// </summary>
    public void Start()
    {
        this.request = WebRequest.Create(url) as HttpWebRequest;
        this.request.Timeout = timeout;
        this.request.Method = method;

        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        
        if (this.proxy.Key != null)
        {
            this.request.Proxy = new WebProxy(this.proxy.Key, this.proxy.Value);
        }
        if (this.contentType != null)
        {
            this.request.ContentType = this.contentType;
        }
        if (this.range != -1)
        {
            this.request.AddRange(this.range);
        }
       
        try
        {
            // POST写POST内容
            if (method.Equals("POST"))
            {
                WritePostData();
            }

            AsyncCallback callback = new AsyncCallback(OnResponse);

            this.request.BeginGetResponse(callback, null);
        }
        catch (Exception e)
        {
            CallBack(ERR_EXCEPTION, e.Message);
            if (request != null)
            {
                request.Abort();
            }
        }
    }

    private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
        return true; //总是接受  
    }

    /// <summary>
    /// 处理读取Response
    /// </summary>
    /// <param name="result">异步回到result</param>
    protected void OnResponse(IAsyncResult result)
    {
        //Debug.Log ("Handle Http Response");
        HttpWebResponse response = null;
        try
        {
            // 获取Response
            response = request.EndGetResponse(result) as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                if ("HEAD".Equals(method))
                {
                    // HEAD请求
                    long contentLength = response.ContentLength;
                    CallBack((int)response.StatusCode, contentLength + "");
                    return;
                }
                // 读取请求内容
                Stream responseStream = response.GetResponseStream();
                byte[] buff = new byte[2048];
                MemoryStream ms = new MemoryStream();
                int len = -1;
                while ((len = responseStream.Read(buff, 0, buff.Length)) > 0)
                {
                    ms.Write(buff, 0, len);
                }
                // 清理操作
                responseStream.Close();
                response.Close();
                request.Abort();
                // 调用回调
                CallBack((int)response.StatusCode, ms.ToArray());
            }
            else
            {
                CallBack((int)response.StatusCode, "");
            }
        }
        catch (Exception e)
        {
            CallBack(ERR_EXCEPTION, e.Message);
            if (request != null)
            {
                request.Abort();
            }
            if (response != null)
            {
                response.Close();
            }
        }
    }
    /// <summary>
    /// 回调
    /// </summary>
    /// <param name="code">编码</param>
    /// <param name="content">内容</param>
    private void CallBack(int code, string content)
    {
      //  Debug.LogFormat("Handle Http Callback, code:{0}", code);
        if (callback != null)
        {
            HTTPResponse response = new HTTPResponse();
            response.StatusCode = code;
            response.Error = content;
            callback(response);
        }
    }
    /// <summary>
    /// 回调
    /// </summary>
    /// <param name="code">编码</param>
    /// <param name="content">内容</param>
    private void CallBack(int code, byte[] content)
    {
        if (callback != null)
        {
            HTTPResponse response = new HTTPResponse(content);
            response.StatusCode = code;
            callback(response);
        }
    }
    /// <summary>
    /// 写Post内容
    /// </summary>
    private void WritePostData()
    {
        if (null == postBuilder || postBuilder.Length <= 0)
        {
            return;
        }
        byte[] bytes = Encoding.UTF8.GetBytes(postBuilder.ToString());
        Stream stream = request.GetRequestStream();
        stream.Write(bytes, 0, bytes.Length);
        stream.Close();
    }
    /// <summary>
    /// URLEncode
    /// </summary>
    /// <returns>encode value</returns>
    /// <param name="value">要encode的值</param>
    private string UrlEncode(string value)
    {
        StringBuilder sb = new StringBuilder();
        byte[] byStr = System.Text.Encoding.UTF8.GetBytes(value);
        for (int i = 0; i < byStr.Length; i++)
        {
            sb.Append(@"%" + Convert.ToString(byStr[i], 16));
        }
        return (sb.ToString());
    }
}