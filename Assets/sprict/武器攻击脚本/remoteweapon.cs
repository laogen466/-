using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class remoteweapon : weaponbase
{
    // Start is called before the first frame update
    public GameObject bullet;
    // Update is called once per frame
    void Awake()
    {
        bullet=Resources.Load<GameObject>("prefab/bullet");
        weapondata=GameManager._instance.currentweapon;
    }
    void Start()
    {
        bullet.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>(getbulletsprite(weapondata.name));
    }
    string getbulletsprite(string name)
    {
        string i;
        switch (name)
        {
            case "医疗枪":i= "Image/武器/医疗枪子弹";break;
            case "手枪":i= "Image/武器/手枪子弹";break;
            case "十字弓":i= "Image/武器/弓箭";break;
            default: i = null; break;   
        }
        return i;
        
    }
    void Update()
    {
        Aiming();
        if(isattack)
        Fire();
        if (iscooling)
        {
            attackTimer+=Time.deltaTime;
            if (attackTimer >= weapondata.cooling)
            {
                attackTimer=0;
                iscooling=false;
            }
        }
    }

    void Fire()
    {
        if (iscooling)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(player._instanc.longattack,transform.position,1f);
        bullet go=Instantiate(bullet,transform.position,transform.localRotation).GetComponent<bullet>();
        go.settarget(enemy,weapondata.damage);
        iscooling=true;
    }
}
