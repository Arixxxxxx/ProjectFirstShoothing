using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidBullet : MonoBehaviour
{
    Player player;
    Transform player_tr;
    float BulletSpeed;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        player_tr = player.GetComponent<Transform>();
        BulletSpeed = 10;
    }
    void Start()
    {
        
    }

 
    void Update()
    {
        GuidBullets();
    }

    private void GuidBullets()
    {
        //Vector3 TargetDir = player_tr.transform.position - transform.position;
        //Quaternion targetRo = Quaternion.LookRotation(TargetDir);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRo, Time.deltaTime * BulletSpeed);

        //무한 유도미사일 구현

        transform.Translate(Vector3.left * Time.deltaTime * BulletSpeed);
        transform.rotation = Quaternion.Euler(0, 0, Quaternion.FromToRotation(Vector3.right,transform.position - player_tr.position).eulerAngles. z);
    }
}
