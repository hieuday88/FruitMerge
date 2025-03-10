using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyObjectPools : Singleton<MyObjectPools>
{
    GameObject tmp;
    Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    public GameObject GetObject(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new ObjectPool());
        }
        return pools[prefab].Get(prefab);
    }

    public GameObject GetObject(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent = null)
    {
        tmp = GetObject(prefab);
        tmp.transform.position = pos;
        tmp.transform.rotation = rot;
        tmp.transform.SetParent(parent);
        return tmp;
    }

    public GameObject GetObject(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        tmp = GetObject(prefab);
        tmp.transform.position = pos;
        tmp.transform.rotation = rot;
        return tmp;
    }

    public T GetObject<T>(GameObject prefab) where T : Component
    {
        return GetObject(prefab).GetComponent<T>();
    }

    public T GetObject<T>(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent = null) where T : Component
    {
        return GetObject(prefab, pos, rot, parent).GetComponent<T>();
    }
}
