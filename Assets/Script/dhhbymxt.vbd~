using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    
    void Awake()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    void BulletMove()
    {
        transform.Translate(Vector3.left * 5 * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6) 
        {
            Player sc = collision.gameObject.GetComponent<Player>();
            sc.OnDamaged();
            Destroy(gameObject);
        }
    }
}
