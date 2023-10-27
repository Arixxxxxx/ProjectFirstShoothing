using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public enum EnemyType
    {
        Small,
        Medium,
        Large
    }
    [SerializeField] EnemyType Enemy;

    [Header("�� ��ü ����")]
    [SerializeField] float HP = 5f;
    [SerializeField] float Speed = 1f;

    [Header("��������Ʈ")]
    [SerializeField] Sprite[] Enermy_s;

    private SpriteRenderer SR_Enermy;
    [SerializeField] GameObject Explosion;
    [SerializeField] GameObject[] Items;
    [SerializeField] bool Haveitem;
    bool isok = true;
    


    private void Awake()
    {
        SR_Enermy = GetComponent<SpriteRenderer>();
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        enermymoving();
        
    }

    private void enermymoving()
    {
        transform.position += transform.up * -1 * Speed * Time.deltaTime;
    }

    //���ʹ� �µ�����
    public void HitEnermy(int DMG)
    {
        HP -= DMG;
        
        if (HP <= 0 && isok)
        {
            GamaManager.instance.Killcount++;
            switch (Enemy)
             {
                case EnemyType.Small:
                    isok = false;
                    GamaManager.instance.TotalPoint += 25;
                    
                    break;

                case EnemyType.Medium:
                    isok = false;
                    GamaManager.instance.TotalPoint += 50;
                    break;

                case EnemyType.Large:
                    isok = false;
                    GamaManager.instance.TotalPoint += 150;
                    break;

             }

            Destroy(gameObject) ;
            GameObject ob = Instantiate(Explosion, transform.position, Quaternion.identity, transform.parent);
            Explsion obj = ob.GetComponent<Explsion>();
            obj.SetScale(SR_Enermy.sprite.rect.width);

            if (Haveitem)
            {
                Instantiate(Items[Random.Range(0,Items.Length)], transform.position, Quaternion.identity, transform.parent);
            }
    
        }

        else
        {
            SR_Enermy.sprite = Enermy_s[1];
            Invoke("DefaultSprite", 0.5f);
        }
    }

    private void DefaultSprite()
    {
        SR_Enermy.sprite = Enermy_s[0];
    }

    public void HaveItemSapwn()
    {
        Haveitem = true;
        SR_Enermy.color = new Color(255,0,0);
    }

    public EnemyType RetrunType()
    {
        return Enemy;
    }
}


