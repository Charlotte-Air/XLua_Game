using UnityEngine;

public class Gameobject
{
    /// <summary>
    ///  具体对象
    /// </summary>
    public Object Object;

    /// <summary>
    /// 对象名称
    /// </summary>
    public string Name;

    /// <summary>
    /// 销毁时间
    /// </summary>
    public System.DateTime LastUserTime;

    public Gameobject(string name, Object obj)
    {
        Name = name;
        Object = obj;
        LastUserTime = System.DateTime.Now;
    }

}
