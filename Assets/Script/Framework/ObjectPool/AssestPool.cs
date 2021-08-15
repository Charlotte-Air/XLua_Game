using UnityEngine;

public class AssestPool : ObjectBase
{
    public override Object Take(string name)
    {
        return base.Take(name);
    }

    public override void Recycle(string name, Object obj)
    {
        base.Recycle(name, obj);
    }

    public override void Release()
    {
        base.Release();
        foreach (Gameobject item in this.ObjectPools)
        {
            if(System.DateTime.Now.Ticks - item.LastUserTime.Ticks >= ReleaseTime * 10000000)
            {
                Debug.LogFormat("AssestPool->Release->{0} Time:{1}", item.Name, System.DateTime.Now);
                ObjectPools.Remove(item); //移除对象池
                Release(); //递归自己跳出循环
                return;
            }
        }
    }
}
