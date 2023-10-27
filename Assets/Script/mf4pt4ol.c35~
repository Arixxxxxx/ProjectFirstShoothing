using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrouund : MonoBehaviour
{
    bool Chagecolor;

    Transform Bot;
    Transform Mid;
    Transform Top;
    SpriteRenderer SR_Bot;
    SpriteRenderer SR_Mid;
    SpriteRenderer SR_Top;
    Material Mt_B;
    Material Mt_M;
    Material Mt_T;

    Vector2 Vec_B;
    Vector2 Vec_M;
    Vector2 Vec_T;

    private void Awake()
    {
        Bot = transform.GetChild(0);
        Mid = transform.GetChild(1);
        Top = transform.GetChild(2);

        SR_Bot = Bot.GetComponent<SpriteRenderer>();
        SR_Mid = Mid.GetComponent<SpriteRenderer>();
        SR_Top = Top.GetComponent<SpriteRenderer>();

        Mt_B = SR_Bot.material;
        Mt_M = SR_Mid.material;
        Mt_T = SR_Top.material;


    }


    void Update()
    {
        GroundMove();
    }

    void GroundMove()
    {
        if (GamaManager.instance.BackGroundChangeOk && !Chagecolor)
        {
            GamaManager.instance.BoosModeBGM();
            
            SR_Bot.color = new Color(1, 0, 0, 1);
            Chagecolor=true;

        }
        Vec_B = Mt_B.mainTextureOffset;
        Vec_M = Mt_M.mainTextureOffset;
        Vec_T = Mt_T.mainTextureOffset;

        Vec_B.y = Mathf.Repeat(Vec_B.y, 1);
        Vec_M.y = Mathf.Repeat(Vec_M.y, 1);
        Vec_T.y = Mathf.Repeat(Vec_T.y, 1);

        Vec_B += new Vector2(0, 0.1f) * Time.deltaTime;
        Vec_M += new Vector2(0, 0.15f) * Time.deltaTime;
        Vec_T += new Vector2(0, 0.2f) * Time.deltaTime;

        Mt_B.mainTextureOffset = Vec_B;
        Mt_M.mainTextureOffset = Vec_M;
        Mt_T.mainTextureOffset = Vec_T;

    }

}
