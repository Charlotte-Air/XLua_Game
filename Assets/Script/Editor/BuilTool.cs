using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class BuilTool : Editor
{
    [MenuItem("Tools/Build Windows Bundle")]
    static void BundleWindowsBuild()
    {
        Build(BuildTarget.StandaloneWindows);
    }
    [MenuItem("Tools/Build Android Bundle")]
    static void BundleAndroidBuild()
    {
        Build(BuildTarget.Android);
    }
    [MenuItem("Tools/Build iOS Bundle")]
    static void BundleiOSBuild()
    {
        Build(BuildTarget.iOS);
    }

    static void Build(BuildTarget target)
    {
        List<AssetBundleBuild> assetBundleBuilds = new List<AssetBundleBuild>(); //宿主列表
        List<string> bundlieInfos = new List<string>(); //文件信息列表
        string[] files = Directory.GetFiles(PathUtil.BuildResourcesPath,"*", SearchOption.AllDirectories);
        for (int i = 0; i < files.Length; i++)
        {
            if(files[i].EndsWith(".meta")) //排除meta文件
                continue;
            AssetBundleBuild assetBundle = new AssetBundleBuild();

            string fileName = PathUtil.GetStandardPath(files[i]); //处理路径斜杠
            Debug.Log("file:" +fileName);

            string assetName = PathUtil.GetUnityPath(fileName);
            assetBundle.assetNames = new string[] {assetName};
            string bundleName = files[i].Replace(PathUtil.BuildResourcesPath, "").ToLower();
            assetBundle.assetBundleName = bundleName + ".ab";
            assetBundleBuilds.Add(assetBundle);
            //添加文件与依赖信息
            List<string> dependenceInfo = GetDependence(assetName);
            string bundleInfo = assetName + "|" + bundleName + ".ab";
            if (dependenceInfo.Count > 0)
                bundleInfo = bundleInfo + "|" + string.Join("|", dependenceInfo);
            bundlieInfos.Add(bundleInfo);
        }
        if (Directory.Exists(PathUtil.BuildeOutPath))
            Directory.Delete(PathUtil.BuildeOutPath, true);
        Directory.CreateDirectory(PathUtil.BuildeOutPath);

        BuildPipeline.BuildAssetBundles(PathUtil.BuildeOutPath,assetBundleBuilds.ToArray(),BuildAssetBundleOptions.None, target);  //构建Build

        File.WriteAllLines(PathUtil.BuildeOutPath + "/" + AppConst.FileListName, bundlieInfos);
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 获取依赖文件列表
    /// </summary>
    /// <param name="curFile"></param>
    /// <returns></returns>
    static List<string> GetDependence(string curFile)
    {
        List<string> dependenceList = new List<string>();
        string[] files = AssetDatabase.GetDependencies(curFile);
        dependenceList = files.Where(file => !file.EndsWith(".cs") && !file.Equals(curFile)).ToList();  //排除代码文件与自身
        return dependenceList;
    }

}
