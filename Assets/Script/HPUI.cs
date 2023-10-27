using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    Player player;
    Image G;
    Image M;
    Image F;

    private void Awake()
    {
        
            player = GameObject.FindAnyObjectByType<Player>();
            G = transform.GetChild(0).GetComponent<Image>();
            M = transform.GetChild(1).GetComponent<Image>();
            F = transform.GetChild(2).GetComponent<Image>();
            
    }
   

    
    void Update()
    {
        PlayerCurHpForntUI(GamaManager.instance.CurHP, GamaManager.instance.MaxHP);
        BossCurHpForntUI(GamaManager.instance.BossCurHP, GamaManager.instance.BossMaxHP);
        FollowPlayer();
        FillAction();
        End();
    }

    private void End()
    {
        if (GamaManager.instance.BossDestory)
        {
            gameObject.SetActive(false);
        }
    }
    private void FollowPlayer()
    {
        //플레이어 레이어 일때만 쫓아다님 BOSS HPBAR랑 같이써야됨
        if(gameObject.tag == "PlayerHPBAR")
        {
            Vector3 PlayerPosition = player.transform.position;

            transform.position = PlayerPosition + new Vector3(-0.6f, 0);
        }
       
    }

    private void FillAction()
    {
        if (M.fillAmount > F.fillAmount)
        {
            M.fillAmount -= 0.1f * Time.deltaTime;
            
            if (M.fillAmount == F.fillAmount)
            {
                M.fillAmount = F.fillAmount;
            }
        }
    }

    private void PlayerCurHpForntUI(float _CurHP, float _MaxHP)
    {
           if (gameObject.tag != "PlayerHPBAR")
           {
              return;
           }

           if (!player.gameObject.activeSelf)
           {
                F.fillAmount = 0;
           }
            else
            {
                F.fillAmount = _CurHP / _MaxHP;
            }
      
    }
    private void BossCurHpForntUI(float _CurHP, float _MaxHP)
    {
         if (gameObject.tag != "BossHPBAR")
         {
            return;
         }

            F.fillAmount = _CurHP / _MaxHP;

        
    }

    //플레이어 사망시 UI활성상태
    public void PlayerDestory(bool Active)
    {
        if(!Active)
        {
            gameObject.SetActive(false);
        }

        if(Active)
        {
            gameObject.SetActive(true);
        }
    }
}
