using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

public class enemypool : MonoBehaviour
{
    // Start is called before the first frame update
    public static enemypool instance;

    [Header("配置")]
    public GameObject enemyprefab;
    public int defaultcap=20;
    public int maxcap=50;

    private ObjectPool<GameObject> pool;

    void Awake()
    {
        instance=this;

        pool=new ObjectPool<GameObject>(
            createFunc:createenemy,
            actionOnGet:Ongetenemy,
            actionOnRelease:onreleaseenemy,
            actionOnDestroy:ondestroyenemy,
            collectionCheck: true,         // 开启收集检查，防止同一个对象被重复释放（编辑器下有效）
            defaultCapacity: defaultcap,
            maxSize: maxcap
        );
    }
        GameObject createenemy()
        {
            GameObject go=Instantiate(enemyprefab,transform);
            go.SetActive(false);
            return go;
        }
        void Ongetenemy(GameObject go)
        {
            go.SetActive(true);
        }
        void onreleaseenemy(GameObject go)
        {
            go.SetActive(false);
        }
        void ondestroyenemy(GameObject go)
        {
            Destroy(go);
        }
    
    public GameObject GetEnemy()
    {
        return pool.Get();
    }
    public void ReleasEenemy(GameObject go)
    {
        pool.Release(go);
    }
 }

