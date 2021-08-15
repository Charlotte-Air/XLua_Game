using System;
using System.IO;
using UnityEngine;

public class FileUtil
{
    /// <summary>
    /// 检测文件存在
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static bool IsExists(string path)
    {
        FileInfo file = new FileInfo(path);
        return file.Exists;
    }

    /// <summary>
    /// 写入文件
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="data">文件数据[ ]</param>
    public static void WriteFile(string path,byte [] data)
    {
        path = PathUtil.GetStandardPath(path);  //获取标准路径
        string dir = path.Substring(0, path.LastIndexOf("/"));  //获取文件夹路径
        if (!Directory.Exists(dir)) //判断文件夹是否存在
        {
            Directory.CreateDirectory(dir); 
        }
        FileInfo file = new FileInfo(path);
        if (file.Exists) //判断文件是否存在
        {
            file.Delete();
        }
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) //创建文件并写入
            {
                fs.Write(data,0,data.Length);
                fs.Close();
            }
        }
        catch(IOException e)
        {
            Debug.LogError(e.Message);
        }
    }
}

