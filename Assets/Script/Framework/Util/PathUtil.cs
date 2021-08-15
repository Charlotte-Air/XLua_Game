using UnityEngine;

public class PathUtil
{
    ///<summary>
    /// Assets根目录
    /// </summary>
    public static readonly string AssetsPath = Application.dataPath;
    ///<summary>
    /// Build输入目录
    /// </summary>
    public static readonly string BuildResourcesPath = AssetsPath + "/AssetBundlesLocal/";
    ///<summary>
    /// Build输出目录
    /// </summary>
    public static readonly string BuildeOutPath = Application.streamingAssetsPath;
    ///<summary>
    /// Build资源路径
    /// </summary>
    public static string BundleResourcePath
    {
        get
        {
            if (AppConst.gameMode == GameMode.UpdateMode)
                return ReadWritePath;
            return ReadPath;
        }
    }

    /// <summary>
    /// 只读目录
    /// </summary>
    public static readonly string ReadPath = Application.streamingAssetsPath;
    /// <summary>
    /// 可读写目录
    /// </summary>
    public static readonly string ReadWritePath = Application.persistentDataPath;
    /// <summary>
    /// Lua目录路径
    /// </summary>
    public static readonly string LuaPath = "Assets/AssetBundlesLocal/LuaScripts";

    /// <summary>
    /// 获取Unity相对路径
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetUnityPath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;
        return path.Substring(path.IndexOf("Assets"));
    }

    /// <summary>
    /// 获取标准路径
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetStandardPath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;
        return path.Trim().Replace("\\", "/");
    }


    #region 获取资源接口

    ///<summary>
    /// 获取Lua路径
    /// </summary>
    public static string GetLuaPath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/LuaScripts/{0}.bytes", name);
    }

    ///<summary>
    /// 获取UI路径
    /// </summary>
    public static string GetUIPath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/UI/prefabs/{0}.prefab", name);
    }

    ///<summary>
    /// 获取场景路径
    /// </summary>
    public static string GetScenePath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/Scenes/{0}.unity", name);
    }

    ///<summary>
    /// 获取特效路径
    /// </summary>
    public static string GetEffectPath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/Effect/prefabs/{0}.prefab}", name);
    }

    ///<summary>
    /// 获取模型路径
    /// </summary>
    public static string GetModelPath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/Model/prefabs/{0}.prefab", name);
    }

    ///<summary>
    /// 获取音乐路径
    /// </summary>
    public static string GetMusicPath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/Audio/Music/{0}", name);
    }

    ///<summary>
    /// 获取音效路径
    /// </summary>
    public static string GetSoundPath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/Audio/Sound/{0}", name);
    }

    ///<summary>
    /// 获取贴图路径
    /// </summary>
    public static string GetSpritePath(string name)
    {
        return string.Format("Assets/AssetBundlesLocal/Sprite/{0}", name);
    }

#endregion


}
