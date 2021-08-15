using UnityEngine;

public class ObjectPool : ObjectBase
{
    public override Object Take(string name)
    {
        Object obj = base.Take(name);
        if (obj == null)
        {
            return null;
        }

        GameObject go =obj as GameObject;
        go.SetActive(true);
        return obj;
    }

    public override void Recycle(string name, Object obj)
    {
        GameObject go = obj as GameObject;
        go.SetActive(false);
        go.transform.SetParent(this.transform,false);
        base.Recycle(name,obj);
    }

    public override void Release()
    {
        base.Release();
        foreach (Gameobject item in this.ObjectPools)
        {
            if (System.DateTime.Now.Ticks - item.LastUserTime.Ticks >= ReleaseTime * 10000000)
            {
                Debug.LogFormat("GameObjectPool->Release->Time:{0}", System.DateTime.Now);
                Destroy(item.Object);
                this.ObjectPools.Remove(item); //移除对象池
                Release(); //递归自己跳出循环
                return;
            }
        }
    }

}
