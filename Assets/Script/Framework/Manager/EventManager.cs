using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /// <summary>
    /// 多播委托
    /// </summary>
    /// <param name="args"></param>
    public delegate void EnventHandler(object args);

    /// <summary>
    /// 事件集合
    /// </summary>
    private Dictionary<int, EnventHandler> envents = new Dictionary<int, EnventHandler>();

    /// <summary>
    /// 订阅事件
    /// </summary>
    /// <param name="id"></param>
    /// <param name="envent"></param>
    public void Subscribe(int id, EnventHandler envent)
    {
        if (envents.ContainsKey(id))
        {
            envents[id] += envent;
        }
        else
        {
            envents.Add(id,envent);
        }
    }

    /// <summary>
    /// 取消订阅
    /// </summary>
    /// <param name="id"></param>
    /// <param name="envent"></param>
    public void UnSubscribe(int id, EnventHandler envent)
    {
        if (envents.ContainsKey(id))
        {
            if (envents[id] != null)
            {
                envents[id] -= envent;
            }

            if (envents[id] == null)
            {
                envents.Remove(id);
            }
        }
    }
    
    /// <summary>
    /// 执行事件
    /// </summary>
    /// <param name="id"></param>
    /// <param name="args"></param>
    public void PerformEvent(int id, object args = null)
    {
        EnventHandler handler;
        if (envents.TryGetValue(id, out handler))
        {
            handler(args);
        }
    }
}
