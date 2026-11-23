using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortweapon : weaponbase
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public Transform weaponparet;
    public float movespeed=8f;
    void Awake()
    {
        weapondata=GameManager._instance.currentweapon;
        weaponparet=GameObject.Find("weapon").GetComponent<Transform>();
        
    }
    void Start()
    {
        playerTransform=player._instanc.transform;
    }
    void Update()
    {
        if(isAming)
        Aiming();

        if (isattack&&!iscooling)
        {
            Fire();
        }
        if (iscooling)
        {
            attackTimer+=Time.deltaTime;
            if (attackTimer > weapondata.cooling)
            {
                iscooling=false;
                attackTimer=0;
                
            }
            
        }
    }
    void Fire()
    {
        if(iscooling)
        return ;
        
        if (enemy != null)
        {
            transform.GetComponent<CapsuleCollider2D>().enabled=true;
            AudioSource.PlayClipAtPoint(player._instanc.shortattack,transform.position,1f);
            StartCoroutine(Goposition());
            isAming=false;
            iscooling=true;
        }
        
        
    }

    IEnumerator Goposition()
    {
        var enemypos =enemy.position+new Vector3(0,enemy.GetComponentInChildren<SpriteRenderer>().size.y/2,0);
        transform.parent=null;
        
        while (Vector2.Distance(transform.position, enemypos) > 0.1f)
        {
            Vector3 dir=(enemypos-transform.position).normalized;
            
            Vector3 moveAmount=dir*movespeed*Time.deltaTime;
            transform.localPosition+=moveAmount;
            yield return null;
        }
        transform.GetComponent<CapsuleCollider2D>().enabled=false;
        StartCoroutine(retrunpositon());
        
    }

    IEnumerator retrunpositon()
    {
    // 🌟 需要知道角色的位置才能飞回来
    
    
    // 计算武器应该回去的世界坐标（角色当前位置 + 本地偏移量）
    Vector3 homeWorldPos = playerTransform.TransformPoint(new Vector3(-0.7f, 0.53f, 0));

    while (Vector3.Distance(transform.position, homeWorldPos) > 0.1f)
    {
        // 注意：角色在飞回途中可能会移动，所以每帧要重新算一次目标位置
        homeWorldPos = playerTransform.TransformPoint(new Vector3(-0.7f, 0.53f, 0));
        
        transform.position = Vector3.MoveTowards(
            transform.position, 
            homeWorldPos, 
            movespeed * Time.deltaTime
        );
        yield return null;
    }

    // 🌟 飞回来之后，重新挂载到角色身上，并重置局部坐标
    transform.SetParent(weaponparet);
    transform.localPosition = new Vector3(-0.7f, 0.53f, 0);
    transform.localRotation = Quaternion.identity;

    isAming = true;
}    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            
            collision.GetComponent<enemy1>().injure(weapondata.damage);
        }
    }
}
