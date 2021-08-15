using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XLua;

public class SysBroadCast : MonoBehaviour
{
    [CSharpCallLua]
  //  public delegate void WXEventHandler(string name);

  //  public static event WXEventHandler onClickToOpen2;
   
  //  public static event WXEventHandler onClickToOpen;
    //
    //public static void click(string name)
    //{

    //    Debug.Log("name " + name);
    //    onClickToOpen(name);
    //}

    public static Action<string> ButtionDelegate = (param) =>
    {
         Debug.Log("TestDelegate in C#->" + param);
    };
}
