using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private static player instanc;
    public static player _instanc
    {
        get
        {
            return instanc;
        }
    }
    public float maxhp=15f;
    public float Speed=5f;
    public float currhp=15f;
    public float experience=0;
    public int Gold;
    public Transform playervis;
    public Animator playeranim;
    public bool isdie=false;
    public GameObject weapon1;
    public AudioClip injureaudio;
    public AudioClip shortattack;
    public AudioClip longattack;
    void Awake()
    {
        instanc=this;
        playervis=transform.Find("vis");
        playeranim=GameObject.Find("vis").GetComponent<Animator>();
        weapon1=GameObject.Find("weapon1");
    }
    //public Animation
    void Start()
    {
        SpriteRenderer vis=playervis.GetComponent<SpriteRenderer>();
        vis.sprite=Resources.Load<Sprite>(GameManager._instance.currentrole.avatar);
        weapon1.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>(GameManager._instance.currentweapon.avatar);
        if (GameManager._instance.currentweapon.isLong == 0)
        {
            weapon1.AddComponent<shortweapon>();
        }
        else
        {
            weapon1.AddComponent<remoteweapon>();
        }
    }
    void Update()
    {
        move();
        
    }

    void move()
    {
        float movehorizontal=Input.GetAxisRaw("Horizontal");
        float movevertical=Input.GetAxisRaw("Vertical");
        if (movehorizontal > 0&&!isdie)
        {
            playervis.localRotation=Quaternion.Euler(0,0,0);
            
            
        }else if (movehorizontal < 0&&!isdie)
        {
            playervis.localRotation=Quaternion.Euler(0,180,0);
            
        }
        
        Vector2 movement=new Vector2(movehorizontal,movevertical);
        if (movement.magnitude > 0)
        {
            playeranim.SetBool("isrun",true);
        }
        else playeranim.SetBool("isrun",false);
        movement.Normalize();
        transform.Translate(movement*Speed*Time.deltaTime);
    }
    
    public void injured(float damage)
    {
        currhp-=damage;
        AudioSource.PlayClipAtPoint(injureaudio,transform.position,1f);
        Gamepanel._instance.renewHp();
        if (currhp <= 0)
        {
            currhp=0;
            Die();
            isdie=true;
        }
    }
    public void Die()
    {
        Gamepanel._instance.fail();
        Time.timeScale=0;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gold"))
        {
            Destroy(collision.gameObject);
            Gold+=1;
            experience++;
            Gamepanel._instance.renewgold();
            Gamepanel._instance.renewExperience();
           
        }
    }
}
