using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sun : MonoBehaviour
{
    Image Suns;
   [SerializeField] Sprite[] SunAndMoon;
    SpriteRenderer Sr;
    [SerializeField] bool isok = true;
    [SerializeField] bool isok2;
    Transform Trsun;

    private void Awake()
    {
        Suns = GetComponent<Image>();
        Sr = GetComponent<SpriteRenderer>();
        Trsun = GetComponent<Transform>();
    }

    void Update()
    {
        SunMove();
    }

    private void SunMove()
    {
        if (isok)
        {

            float Ping = Mathf.PingPong(Time.time * 3, 6) - 3;
            Quaternion Qua = Quaternion.Euler(0, 0, Ping);
            transform.rotation = Qua;

        }


        // 달 -> 달로 변경
        if (GamaManager.instance.BackGroundChangeOk)
        {
            if (isok)
            {
                Color col = Sr.color;
                col.a -= 0.8f * Time.deltaTime;
                Sr.color = col;

                if(col.a <= 0.1f)
                {
                    isok = false;
                    isok2 = true;
                }

            }

            if (isok2)
            {
                Sr.sprite = SunAndMoon[1];
                
                if (Sr.sprite = SunAndMoon[1])
                {
                    Trsun.transform.localScale = new Vector2(1, 1);
                    Color col = Sr.color;
                    col.a += 0.8f * Time.deltaTime;
                    Sr.color = col;
                }

            }

        }
    }
}
