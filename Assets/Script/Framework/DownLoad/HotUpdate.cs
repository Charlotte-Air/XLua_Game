using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class HotUpdate : MonoBehaviour
{
    private byte[] ReadPathFildListData;
    private byte[] ServerFileListData;
    private int DownloadCount;
    private GameObject Loadingobj;

    internal class DownFileInfo
    {
        public string url;
        /// <summary>
        /// 相对路径
        /// </summary>
        public string fileName;
        public DownloadHandler fildData;
    }

    void Start()
    {
        GameObject go = Resources.Load<GameObject>("LoadingUI");
        Loadingobj = Instantiate(go);
        Loadingobj.transform.SetParent(this.transform);

        if (IsFirstInstall())
        {
            ReleaseResoures();
        }
        else
        {
            CheckUpdate();
        }
    }

    private bool IsFirstInstall()
    {
        bool isExistsReadPath = FileUtil.IsExists(Path.Combine(PathUtil.ReadPath, AppConst.FileListName));  //判断只读目录是否存在版本文件
        bool isExistsReadWritePath = FileUtil.IsExists(Path.Combine(PathUtil.ReadWritePath, AppConst.FileListName));    //判断可读写目录是否存在版本文件
        return isExistsReadPath && !isExistsReadWritePath;
    }

    #region 释放资源
    private void ReleaseResoures()
    {
        string url = Path.Combine(PathUtil.ReadPath, AppConst.FileListName);
        DownFileInfo info = new DownFileInfo();
        info.url = url;
        StartCoroutine(DownLoadFild(info, OnDownLoadReadPathFileListActoin));
    }

    private void OnDownLoadReadPathFileListActoin(DownFileInfo file)
    {
        ReadPathFildListData = file.fildData.data;
        List<DownFileInfo> fileInfos = GetFildList(file.fildData.text, PathUtil.ReadPath);  //解析文件信息
        StartCoroutine(DownLoadFild(fileInfos, OnReleaseFileActoin, OnReleaseAllFileActoin));  //下载多文件
        //Loadingui.InitProgress(100, "正在释放资源,~不消耗流量");
    }

    private void OnReleaseFileActoin(DownFileInfo file)
    {
        Debug.Log("OnReleaseFileActoin->"+file.fileName);
        string writeFile = Path.Combine(PathUtil.ReadWritePath, file.fileName);
        FileUtil.WriteFile(writeFile, file.fildData.data);
    }

    private void OnReleaseAllFileActoin()
    {
        FileUtil.WriteFile(Path.Combine(PathUtil.ReadWritePath, AppConst.FileListName), ReadPathFildListData);
        CheckUpdate();
    }
    #endregion


    #region 检测更新
    private void CheckUpdate()
    {
        DownloadCount = 0;
        string url = Path.Combine(AppConst.ResouresUrl, AppConst.FileListName);
        DownFileInfo info = new DownFileInfo();
        info.url = url;
        StartCoroutine(DownLoadFild(info, OnDownLoadServerFileListActoin));
    }

    private void OnDownLoadServerFileListActoin(DownFileInfo file)
    {
        DownloadCount = 0;
        ServerFileListData = file.fildData.data;
        List<DownFileInfo> fileInfos = GetFildList(file.fildData.text, AppConst.ResouresUrl) ;   //获取资源服务器文件信息
        List<DownFileInfo> DownListFiles = new List<DownFileInfo>(); //下载文件集合
        for (int i = 0; i < fileInfos.Count; i++)
        {
            string localFile = Path.Combine(PathUtil.ReadWritePath, fileInfos[i].fileName);
            if (!FileUtil.IsExists(localFile))
            {
                fileInfos[i].url = Path.Combine(AppConst.ResouresUrl, fileInfos[i].fileName);
                DownListFiles.Add(fileInfos[i]);
            }
        }

        if (DownListFiles.Count > 0)
        {
            StartCoroutine(DownLoadFild(fileInfos, OnUpdateFileActoin, OnUpdateAllFileActoin));
            //Loadingui.InitProgress(DownListFiles.Count, "正在更新中......");
        }
        else
            EnterGame();
    }

    private void OnUpdateFileActoin(DownFileInfo file)
    {
        Debug.Log("OnUpdateFileActoin->"+file.url);
        string writeFile = Path.Combine(PathUtil.ReadWritePath, file.fileName);
        FileUtil.WriteFile(writeFile, file.fildData.data);
        DownloadCount++;
        //Loadingui.UpdateProgress(DownloadCount);
    }

    private void OnUpdateAllFileActoin()
    {
        FileUtil.WriteFile(Path.Combine(PathUtil.ReadWritePath, AppConst.FileListName), ServerFileListData);
        EnterGame();
        //Loadingui.InitProgress(0, "正在载入中......");
    }

    #endregion
    

    #region 进入游戏
    private void EnterGame()
    {
        Destroy(Loadingobj);
    }

    #endregion


    #region 文件处理

    /// <summary>
    /// 单个文件下载
    /// </summary>
    /// <param name="info">文件信息</param>
    /// <param name="action">回调</param>
    /// <returns></returns>
    IEnumerator DownLoadFild(DownFileInfo info,Action<DownFileInfo> action)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(info.url);
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log("Download Fild Error->" + info.url);
            yield break; 

        }
        yield return new WaitForSeconds(0.2f);

        info.fildData = webRequest.downloadHandler;
        action?.Invoke(info);
        webRequest.Dispose(); //释放
    }

    /// <summary>
    /// 多个文件下载
    /// </summary>
    /// <param name="infos">文件信息列表</param>
    /// <param name="action">单个下载回调</param>
    /// <param name="downLoadAllAction">结束下载回调</param>
    /// <returns></returns>
    IEnumerator DownLoadFild(List<DownFileInfo> infos, Action<DownFileInfo> action,Action downLoadAllAction)
    {
        foreach (DownFileInfo info in infos)
        {
            yield return DownLoadFild(info, action);
        }
        downLoadAllAction?.Invoke();
    }

    /// <summary>
    /// 获取文件信息
    /// </summary>
    private List<DownFileInfo> GetFildList(string fileData,string path)
    {
        string content = fileData.Trim().Replace("\r", "");  //去除符号
        string[] files = content.Split('\n'); //切割每一行
        List<DownFileInfo> downFileInfos = new List<DownFileInfo>(files.Length);
        for (int i = 0; i < files.Length; i++)
        {
            string [] info = files[i].Split('|'); //切割信息
            DownFileInfo fileInfo = new DownFileInfo();
            fileInfo.fileName = info[1];
            fileInfo.url = Path.Combine(path, info[1]);
            downFileInfos.Add(fileInfo);
        }
        return downFileInfos;
    }

    #endregion

}
