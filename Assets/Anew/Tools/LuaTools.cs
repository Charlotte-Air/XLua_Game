//using SLua;
using UnityEngine;
using System.Text;
using System;
using DG.Tweening;
//using Spine.Unity;
//using Spine;
using UnityEngine.UI;
using XLua;

//[CustomLuaClass] 
public class LuaTools
{ 
    public static string GetVersion()
    {
        return GameConfig.Version + ":" + GameConfig.Assetversion;
    }

    

    private static string[] DressName = new string[] { "Phiz", "Hairstyle", "Coat", "Pants", "arms" };
     


    [CSharpCallLua]
    public delegate void CallBack(string content);//  

    public static CallBack callBack;

    public static void SendMessage(string v)
    {
        AppBoot.instance.tcpClient.Send(v);
    }

    public static void HttpServer(string path, string data, LuaFunction callback)
    {

        Debug.Log("HttpServer ~!!!!");
        Http("https://" + GameConfig.ServerIP + "/" + path, data, callback);
    }
    public static void Init()
    { 
        callBack = LuaBehaviour.luaEnv.Global.Get<CallBack>("callBack");
    }
    public static void Http(string url, string data, LuaFunction callback)
    {
        if (callBack == null)
        {
            callBack = LuaBehaviour.luaEnv.Global.Get<CallBack>("callBack"); 
        }
         Debug.Log("杨洋  url == " + url );
        if (url == "")
        {
            url = "http://" +  GameConfig.ServerIP  + "/SceneServer";
        }
        Debug.Log("杨洋  url == " + url + "   data ==   " + data);
        HTTPRequest client = new HTTPRequest(url, "POST", 5000, (HTTPResponse response) => {
            if (response.StatusCode == -1)
            {
                Debug.LogError("HTTPResponse error " + response.Error); 
            }
            else
            { 
                Debug.Log("response.GetResponseText()    == " + response.GetResponseText());
               // Debug.Log(AppBoot.instance);
                AppBoot.instance.AddCallFromAsync(() => { callBack(response.GetResponseText()); });
            }
        });
        client.ContentType = "application/x-www-form-urlencoded";
        string str = WWW.EscapeURL(data);
        client.AddPostData("data", str);
        client.Start();
    }

     

    public static void SocketConnet(string ip, int port)
    {
        if (AppBoot.instance.tcpClient != null)
            AppBoot.instance.tcpClient.Close();

        AppBoot.instance.tcpClient = new GameTcpClient(ip, port);
    }
 

    public static long ToUnixTime(string timeString)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
        long t = (DateTime.Parse(timeString).Ticks - startTime.Ticks) / 10000;   //除10000调整为13位 

        return t;
    }
 
  

    public static void DelayCall(float time, Action callback)
    {
//        UnityEngine.Debug.Log(time);
        
        //  UnityEngine.Debug.Log(callback);
        //  UnityEngine.Debug.Log( AppBoot.instance);
        AppBoot.instance.AddDelayCall(time, callback);
    }
    
     
     
    public static void PlaySound(string name)
    {
        AppBoot.instance.sound.PlaySound(name);
    }
    public static void PlaySoundWav(string name)
    {
        AppBoot.instance.sound.PlaySoundWav(name);
    }
    public static void PlayMusic(string name, bool loop)
    {
        AppBoot.instance.sound.PlayMusic(name,loop);
    }

    public static void SetEnableMusic(bool v)
    {
        AppBoot.instance.sound.enableMusic = v;
    }

    public static void SetEnableEffect(bool v)
    {
        AppBoot.instance.sound.enableEffect = v;
    }

    public static bool GetEnableMusic()
    {
        return AppBoot.instance.sound.enableMusic;
    }

    public static bool GetEnableEffect()
    {
        return AppBoot.instance.sound.enableEffect;
    }

}