using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum GameMode
{
    EditorMode,     //编辑器模式
    PackgeBundle, //包装模式
    UpdateMode,  //更新模式
}

public enum GameEvent
{
    GameInit=10000,
    StartLua,
}

public class AppConst
{
    public const  string   BundleExtension = ".ab";
    public const  string   FileListName = "filelist.txt";
    public static GameMode gameMode = GameMode.EditorMode;
    public static bool OpenLog = true;
    /// <summary>
    /// 热更新服务器地址
    /// </summary>
    public const string ResouresUrl = "http://192.168.3.2/AssetBundles";
}
