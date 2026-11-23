using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class weaponbase : MonoBehaviour
{
    // Start is called before the first frame update
    public weapondata weapondata;
    public bool iscooling;
    public bool isattack;
    public float attackTimer=0f;
    public float speed;
    public Transform enemy;
    public float originZ=-40f;
    
    public bool isAming=true;

    public void Aiming()
    {
        Collider2D[] enemiRange=Physics2D.OverlapCircleAll(transform.position,weapondata.range/100,LayerMask.GetMask("enemy"));
        
        if (enemiRange.Length > 0)
        {
            
            isattack=true;
           //Collider2D nearestenemy=enemiRange.OrderBy(enemy=>Vector2.Distance(transform.position,enemy.transform.position)).First();
           Collider2D nearestenemy=enemiRange.OrderBy(GetDistance).First();
           enemy=nearestenemy.transform;
           Vector2 enemypos=enemy.position;
            Vector2 worldDir=enemypos - (Vector2)transform.position;
            Vector2 localDir= transform.parent.InverseTransformDirection(worldDir);
            float angleDegress=Mathf.Atan2(localDir.y,localDir.x)*Mathf.Rad2Deg;
            if (weapondata.isLong==0)
        {
            transform.localEulerAngles=new Vector3(0,0,angleDegress+originZ);
        }
        else if(weapondata.isLong==1&&weapondata.name=="十字弓")
        {
            transform.localEulerAngles=new Vector3(0,0,angleDegress+originZ);
        }
        else
        {
            transform.localEulerAngles=new Vector3(0,0,angleDegress);
        }
            
        }
        else
        {
            if (weapondata.isLong==0)
        {
            transform.localEulerAngles=new Vector3(0,0,originZ);
        }
        else if(weapondata.isLong==1&&weapondata.name=="十字弓")
        {
            transform.localEulerAngles=new Vector3(0,0,originZ);
        }
        else
        {
            transform.localEulerAngles=new Vector3(0,0,0);
        }
            isattack=false;
            enemy=null;
        }
        
    }


    float GetDistance(Collider2D enemy)
{
    return Vector2.Distance(transform.position, enemy.transform.position);
}
}
