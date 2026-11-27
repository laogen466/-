
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class wavecolltrol : MonoBehaviour
{
    // Start is called before the first frame update
    private static wavecolltrol instance;
    public static wavecolltrol _instance
    {
        get
        {
            return instance;
        }
    }
    public float wavetime;
    public int currtwave=1;
    public GameObject enemy;
    public Bounds _maps;
    public List<GameObject> enemies;
    void Awake()
    {
        instance=this;
        enemy=Resources.Load<GameObject>("prefab/enemy");
        _maps=GameObject.Find("Map").GetComponent<SpriteRenderer>().bounds;
    }
    
    void Update()
    {
        if (wavetime > 0)
        {
            wavetime-=Time.deltaTime;
            if (wavetime < 0.1f)
            {
                wavetime=0;
               
                Gamepanel._instance.success();
            }
        }
        Gamepanel._instance.renewcountdown(wavetime);
    }

    
    void Start()
    {
        wavetime=GameManager._instance.currentwave*5+15f;
        Enemystart();
    }
    void Enemystart()
    {
        StartCoroutine(SwawnEnemy());
    }
    IEnumerator SwawnEnemy()
    {
        while (true)
        {
            if(wavetime <= 0 || player._instanc.isdie)
            yield break;
            
            var spanposition=getspanposition(_maps);
            GameObject go=enemypool.instance.GetEnemy();
            go.transform.position=spanposition;
            go.transform.rotation=Quaternion.identity;
            enemies.Add(go);
            yield return new WaitForSeconds(0.5f);
        }
    }
    Vector3 getspanposition(Bounds bounds)
    {
        float safe=5f;
        float randomx=Random.Range(bounds.min.x+safe,bounds.max.x-safe);
        float randomy=Random.Range(bounds.min.y+safe,bounds.max.y-safe);
        float z=0;
        return new Vector3(randomx,randomy,z);
    }
}
