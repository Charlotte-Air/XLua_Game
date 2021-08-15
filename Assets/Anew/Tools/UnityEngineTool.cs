using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.Text;
using System;
[LuaCallCSharp]
public class UnityEngineTool  {
    // 获取本地存储
   public static string GetPlayerPrefs(string key)
    {   
        return PlayerPrefs.GetString(key, "");
    }
    // 设置本地存储
    public static void SetPlayerPrefs(string key , string value)
    {
        PlayerPrefs.SetString(key, value);

    }
    // 检查特殊字符串
    public static  bool Check_account(string account)
    {
        bool state = false; 
        //Debug.Log ("account==" + account); 
        for (int i = 0; i < account.Length; i++)
        { 
            ////Debug.Log ("这份特殊的字符是==="+(int)account [i]); 
            if (((int)account[i]) >= 48 && (int)account[i] <= 57 || (int)account[i] == 64 || (int)account[i] == 46 || ((int)account[i]) >= 97 && (int)account[i] <= 122 || ((int)account[i]) >= 65 && (int)account[i] <= 90)
            {
                state = true;
            }
            else
            {
                ////Debug.Log ("这份特殊的字符是===" + account [i]);
               // Public.instance.warning("含有特殊字符！");
                return state = false;
            }
        } 
        return state; 
    } 
    public static string Base64Encode(Encoding encodeType, string source)
    {
        string encode = string.Empty;
        byte[] bytes = encodeType.GetBytes(source);
        try
        {
            encode = Convert.ToBase64String(bytes);
        }
        catch
        {
            encode = source;
        }
        return encode;
    }

    public static string Base64Encode(string source)
    {
        return Base64Encode(Encoding.UTF8, source);
    }

    public static string SplitStr(string source,string flag,int num )
    {

       // //Debug.Log("source "  + source);
        return source.Split(flag.ToCharArray())[num];
    }

    public static void OpenModule(string name )
    {
        
    }

 

    //当页面存在了  未到开启 但是已经预制出来了   玩家点则应当显示 掌门多少级开启    如果已经达到了等级 则直接打开就好可
    // public static bool IsShowIsEnable(string pageName, ref string backWram)
    // {//将玩家点击的页面名字传进来
      
    //     //字典中存在这个页面的名字 就走这个不存在就不走这个
    //     if (GameMainData.instance.OpenPageInfoDataShow.ContainsKey(pageName) == true)
    //     {
    //         if (int.Parse(GameMainData.instance.OpenPageInfoDataShow[pageName].enableLevel) > GameMainData.instance.level)
    //         {//如果玩家的等级小于可以开启的等级显示这个
    //             Public.instance.warning("掌门功能 " + GameMainData.instance.OpenPageInfoDataShow[pageName].enableLevel + " 级开启！");
    //             backWram = "掌门功能 " + GameMainData.instance.OpenPageInfoDataShow[pageName].enableLevel + " 级开启！";
    //             // return ISOpenPage = false;
    //             return false;
    //         }
    //     }
    //     else
    //     {
    //         //Debug.Log("---------------------------------------------穿回来的的游戏的页面是穿回来的页面名字 字典不存在=" + pageName);
    //     }
    //     //return ISOpenPage = true;
    //     return true;
    // }
}
