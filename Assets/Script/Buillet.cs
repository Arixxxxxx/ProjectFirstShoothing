using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buillet : MonoBehaviour
{
    private float DMG = 1f;
    private float Speed = 1f;
    private bool isok;

 

   


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        if (gameObject.tag == "Bullet")
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (gameObject.tag == "Bullet2")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (gameObject.tag == "SuperBullet")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Update()
    {
        ShootMove();


    }

    public void SetBullet(float _DMG, float _SPEED)
    {
        DMG = _DMG;
        Speed = _SPEED;
    }


    private void ShootMove()
    {
        if (gameObject.tag == "Bullet" || gameObject.tag == "Bullet2" || gameObject.tag == "SuperBullet")
        {
            transform.position += Vector3.right * 1 * Speed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.up * 1 * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "SuperBullet" && collision.gameObject.tag == "Enemey" || collision.gameObject.tag == "Boss")
        {
            if (collision.gameObject.tag == "Enemey")
            {
                Enermy SC = collision.gameObject.GetComponent<Enermy>();
                SC.HitEnermy(30);
            }

            else if (gameObject.tag == "SuperBullet" && collision.gameObject.tag == "Boss")
            {
                Boss SC = collision.gameObject.GetComponent<Boss>();
                SC.HitBoss(30);
            }
        }

        if (collision.gameObject.tag == "Enemey" && !isok && (gameObject.tag == "Bullet" || gameObject.tag == "Bullet2"))
        {
            isok = true;

            Enermy SC = collision.gameObject.GetComponent<Enermy>();
            SC.HitEnermy((int)DMG);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boss" && !isok && (gameObject.tag == "Bullet" || gameObject.tag == "Bullet2"))
        {
            Debug.Log("¡¯¿‘");
            isok = true;
            Boss SC = collision.gameObject.GetComponent<Boss>();
            SC.HitBoss((int)DMG);
            Destroy(gameObject);
        }
             

    }

}

