using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    /// <summary>
    /// 自动释放时间
    /// (单位/秒)
    /// </summary>
    protected float ReleaseTime;

    /// <summary>
    /// 上次释放资源时间
    /// (单位/毫微秒)10000000 =1/秒
    /// </summary>
    protected long LastReleaseTime = 0;

    /// <summary>
    /// 对象池
    /// </summary>
    protected List<Gameobject> ObjectPools;

    public void Start()
    {
        LastReleaseTime = System.DateTime.Now.Ticks;
    }

    void Update()
    {
        if (System.DateTime.Now.Ticks - this.LastReleaseTime >= ReleaseTime * 10000000&&this.ObjectPools!=null)
        {
            LastReleaseTime = System.DateTime.Now.Ticks;
            Release();
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="time">释放时间</param>
    public void Init(float time)
    {
        ReleaseTime = time;
        ObjectPools = new List<Gameobject>();
    }

    /// <summary>
    /// 取出对象
    /// </summary>
    /// <param name="name">名称</param>
    /// <returns></returns>
    public virtual Object Take(string name)
    {
        foreach (Gameobject go in this.ObjectPools)
        {
            if (go.Name == name)
            {
                this.ObjectPools.Remove(go);
                return go.Object;
            }
        }
        return null;
    }

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="obj">对象</param>
    public virtual void Recycle(string name, Object obj)
    {
        Gameobject go = new Gameobject(name, obj);
        this.ObjectPools.Add(go);
    }

    /// <summary>
    /// 释放对象
    /// </summary>
    public virtual void Release()
    {
        
    }
     
}
