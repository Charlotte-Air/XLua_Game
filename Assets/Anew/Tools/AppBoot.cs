using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using DG.Tweening;
using System.IO;
//using SDKFly; 
using UnityEngine;

public class AppBoot : MonoBehaviour {

    public static AppBoot instance;

      AudioSource audioMusic;

      AudioSource audioEffect; 

    public GameTcpClient tcpClient;

     public SoundMoudule sound;

    public RectTransform RootUI;

    public List<DelayCall> delayCall = new List<DelayCall>();

#if UNITY_EDITOR

    public bool useAssetBundle;

#endif
    private void Awake()
    {
        instance = this;
        UnityEngine.Debug.Log("AppBoot -> Awake");
    }
  
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(PlayMovie());
    }
  

    private IEnumerator PlayMovie()
    {
#if !UNITY_EDITOR
       // Handheld.PlayFullScreenMovie("logo.mp4", Color.black, FullScreenMovieControlMode.Hidden);
#endif
        yield return new WaitForEndOfFrame();
        // SdkTool.InitSDK(SdkInitComplete);
    }

    private void SdkInitComplete()
    {
#if UNITY_EDITOR
     //   LoadTools.useAssetBundle = useAssetBundle;
#endif
        DOTween.Init();
        GameConfig.Init();
        ServicePointManager.ServerCertificateValidationCallback = (p1, p2, p3, p4) => true;
        Application.logMessageReceived += HandLog;
        DontDestroyOnLoad(this.gameObject);
        Instantiate<GameObject>(Resources.Load<GameObject>("UIGameLoading"), RootUI);
    }

    void HandLog(string logString, string stackTrace, LogType type)
    {
        
    }

   // Action _callback;
    public void Init()  // Init(Action callback,Action<int> SluaTickHandler)
 
    {    audioEffect = GameObject.Find("ASsound").GetComponent<AudioSource>();
         audioMusic = GameObject.Find("ASmusic").GetComponent<AudioSource>();
      //  _callback = callback;
      //  StaticData.Init();
         sound = new SoundMoudule(audioMusic, audioEffect);
      //  slua = new SLuaMoudule(SluaTickHandler, SluaCompleteHandler);
    }
 

    void Update ()
    { 

        if(delayCall.Count > 0)
        {
            for (int i = delayCall.Count - 1; i >= 0; i--)
            {
                //if(delayCall[i].enable)
                //{
                    if (Time.time > delayCall[i].time)
                    {
                        DelayCall d = delayCall[i];
                        delayCall.RemoveAt(i);

                        d.action();

                        //if (d.data == null)
                        //    d.luaCallback.call();
                        //else
                        //    d.luaCallback.call(d.data);
                        //d.luaCallback = null;
                    }
                //}
                //else
                //{
                //    delayCall.RemoveAt(i);
                //}
            }
        }
	}

    private void OnDestroy()
    {
        if (tcpClient != null)
            tcpClient.Close();
    }

    public void AddDelayCall(float time,Action action)
    {
        DelayCall d = new DelayCall() { time = time + Time.time, action = action};
        delayCall.Add(d);
    }

    //public void AddDelayCall(float time, LuaFunction timeCallback)
    //{
    //    DelayCall d = new DelayCall() { time = time + Time.time, luaCallback = timeCallback, data = null };
    //    delayCall.Add(d);
    //}

    //public void AddKeyDelayCall(float time, LuaFunction timeCallback,string key)
    //{
    //    DelayCall d = new DelayCall() { time = time + Time.time, luaCallback = timeCallback, data = null , key = key };
    //    delayCall.Add(d);
    //}

    //public void RemoveDelayCall(string key)
    //{
    //    for (int i = delayCall.Count - 1; i >= 0; i--)
    //    {
    //        if (key == delayCall[i].key)
    //        {
    //            delayCall.RemoveAt(i);
    //        }
    //    }
    //}

    public void AddCallFromAsync(Action action)
    {

        //Debug.Log("AddCallFromAsync ************** ");
        DelayCall d = new DelayCall() { time = 0, action = action};
        delayCall.Add(d);
    }
}

public class DelayCall
{
    public Action action;
    //public LuaFunction luaCallback;
    //public string data;
    public float time;
    //public bool enable=true;
    //public string key;
}
