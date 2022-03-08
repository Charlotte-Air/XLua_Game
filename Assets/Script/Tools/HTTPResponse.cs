using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// HTTP返回内容
/// </summary>
public class HTTPResponse
{
    // 状态码
    private int statusCode;
    // 响应字节
    private byte[] responseBytes;
    // 错误内容
    private string error;
    /// <summary>
    /// 默认构造函数
    /// </summary>
    public HTTPResponse()
    {
    }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="content">响应内容</param>
    public HTTPResponse(byte[] content)
    {
        this.responseBytes = content;
    }
    /// <summary>
    /// 获取响应内容
    /// </summary>
    /// <returns>响应文本内容</returns>
    public string GetResponseText()
    {
        if (null == this.responseBytes)
        {
            return null;
        }
        return Encoding.UTF8.GetString(this.responseBytes);
    }
    /// <summary>
    /// 将响应内容存储到文件
    /// </summary>
    /// <param name="fileName">文件名称</param>
    public void SaveResponseToFile(string fileName)
    {
        if (null == this.responseBytes)
        {
            return;
        }
        // FIXME 路径跨平台问题
        string path = Path.Combine(Application.dataPath + "/StreamingAssets", fileName);
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryWriter writer = new BinaryWriter(fs);
        writer.Write(this.responseBytes);
        writer.Flush();
        writer.Close();
        fs.Close();
    }
    /// <summary>
    /// 获取状态码
    /// </summary>
    /// <value>状态码</value>
    public int StatusCode
    {
        set
        {
            this.statusCode = value;
        }
        get
        {
            return this.statusCode;
        }
    }
    /// <summary>
    /// 获取错误消息
    /// </summary>
    /// <value>错误消息</value>
    public string Error
    {
        set
        {
            this.error = value;
        }
        get
        {
            return this.error;
        }
    }
}