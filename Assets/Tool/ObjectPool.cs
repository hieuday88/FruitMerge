using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ObjectPool
{
    Queue<GameObject> pool = new Queue<GameObject>();
    GameObject tmp;
    ReturnToPool ReturnToPool;
    public GameObject Get(GameObject prefab)
    {
        if (pool.Count > 0)
        {
            tmp = pool.Dequeue();
            tmp.SetActive(true);
            return tmp;
        }
        tmp = Object.Instantiate(prefab);
        ReturnToPool = tmp.AddComponent<ReturnToPool>();
        ReturnToPool.pool = this;
        return tmp;
    }

    public void Return(GameObject prefab)
    {
        pool.Enqueue(prefab);
    }
}
