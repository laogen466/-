using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemy1 : enemybase
{
    // Start is called before the first frame update
    public bool iscontact=false;
    public bool iscooling=false;
    public float damage=3;
    public float attackTime=2;
    public float attackTimer;
    
    void Update()
    {
        goplayer();
        if (iscontact&&!iscooling)
        {
            attack();   
        }
        if (iscooling)
        {
            attackTimer-=Time.deltaTime;
            if (attackTimer <= 0)
            {
                iscooling=false;
            }
        }
        
    }
    //攻击
   
    void attack()
    {
        
        player._instanc.injured(damage);
        iscooling=true;
        attackTimer=attackTime;
        
    }
    
    //受伤
    public void injure(float damage)
    {
        hp-=damage;
        if (hp <= 0)
        Die();
    }
    //死亡
    public void Die()
    {
        EventManager.Instance.Trigger(GameEventType.EnemyDied, this.transform.position);
        enemypool.instance.ReleasEenemy(gameObject);
        Instantiate(goldprefab,transform.position,quaternion.identity);
        
    }

    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            iscontact=true;
        }
    }
     private void OnTriggerExit2D(Collider2D other)     
    {
        if (other.CompareTag("Player"))
        {
            iscontact=false;
        }

    }
}
