using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemypos;
    public float speed=4f;
    public float damage;

    public void settarget(Transform enemy,float d)
    {
        enemypos=enemy;
        damage=d;
    }

    void Update()
    {
        if (enemypos == null)
        {
            Destroy(gameObject);
            return;
        }

        var enemyp =enemypos.position+new Vector3(0,enemypos.GetComponentInChildren<SpriteRenderer>().size.y/2,0);
        transform.position=Vector3.MoveTowards(transform.position,enemyp,speed*Time.deltaTime);

        // if (Vector3.Distance(transform.position, enemypos.position) < 0.1f)
        // {
            
            
        // }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<enemy1>().injure(damage);
        }
    }
}
