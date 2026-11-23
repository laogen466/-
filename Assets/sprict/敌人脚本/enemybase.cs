using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class enemybase : MonoBehaviour
{
    // Start is called before the first frame update
    public enemydata edata;
    
    public float speed=3f;
    public float hp=1;
    public GameObject goldprefab;
    void Awake()
    {
        goldprefab=Resources.Load<GameObject>("prefab/gold");
    }
    //自动寻路
    void Update()
    {
        goplayer();
    }
    public void goplayer()
    {
        Vector3 dir=player._instanc.transform.position-transform.position;
        dir+=new Vector3(0,-0.5f,0);
        
        turnAround();
        dir.Normalize();
        transform.Translate(dir*speed*Time.deltaTime);
    }
   
    //转向
    public void  turnAround()
    {
        if (player._instanc.transform.position.x - transform.position.x>=0.1f)
        {
            transform.localScale= new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z );
        }
        else if (player._instanc.transform.position.x - transform.position.x<0)
          transform.localScale= new Vector3(-Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z );
    }
    
}
