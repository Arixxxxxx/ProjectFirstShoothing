using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Setting Object")]
    [Space]
    [Header("기체 속도")]
    [SerializeField] float M_Speed;
    [Space]
    [Header("미사일 데미지 & 속도")]
    [SerializeField][Tooltip("숫자로입력")] float ShootDMG = 1f;
    [SerializeField][Tooltip("숫자로입력")] float ShootSPD = 1f;
    [Space]
    [Header("참조")]
    [SerializeField][Tooltip("Insert Bullet A")] GameObject BulletDataA;
    [SerializeField][Tooltip("Insert Bullet B")] GameObject BulletDataB;
    [SerializeField][Tooltip("Insert Bullet C")] GameObject BulletDataC;
    [SerializeField][Tooltip("Insert Bullet C")] GameObject BulletDataD;
    [SerializeField][Tooltip("Insert Boom")] GameObject BoomData;
    [SerializeField] Transform BulletStartPoint;
    [SerializeField] Transform Dynamic;
    [SerializeField] GameObject Boom;

    [SerializeField] float KB_F = 10f;
    [SerializeField] float KB_D = 0.5f;
    [Space]

    //오디오, 애니
    public AudioClip Shoot;
    public AudioClip OnDamged;
    public AudioClip OnDestory;
    public AudioClip GetCoin;
    public AudioClip GetPowerBooM;
    public AudioClip BossSpawn;
    public AudioClip BossSound;
    AudioSource Aduio;
    Animator anim;

    // Bool
    bool isKB = false;
    public bool isPlayerDead;
    bool isBoom;
    bool LShift;
    float AddSpeed;
    bool isok = true;
    bool SuperShotCount;




    //시간
    float KB_Time;
    float KB_EndTime;
    float CurTime;
    Vector2 KB_direction;


    //참조
    SpriteRenderer Sr;
    Camera MainCam;
    Rigidbody2D Rb;
    HPUI hpui;


    private void Awake()
    {
        isPlayerDead = true;
        MainCam = Camera.main;
        anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Aduio = GetComponent<AudioSource>();
        hpui = GameObject.FindAnyObjectByType<HPUI>();
        AddSpeed = 1;

    }



    void Update()
    {
        PlayerMoving();
        noCAMOUT();
        ShootBullet();
        KB();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적 기체와 충돌
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            OnDamaged();
        }

        //아이템 획득
                   
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if (isok == false)
            {
                return;
            }
            ItemObject sc = collision.gameObject.GetComponent<ItemObject>();
            ItemObject.Itemtype type = sc.Returntype();

            switch (type)
            {
                case ItemObject.Itemtype.Power:

                    AudioPlay("GetItem");


                    if (GamaManager.instance.CurPower < 2)
                    {
                        isok = false;
                        GamaManager.instance.CurPower++;
                        isok = true;
                    }
                    break;

                case ItemObject.Itemtype.Boom:
                    AudioPlay("GetItem");


                    if (GamaManager.instance.BoomIndex < 3)
                    {
                        isok = false;
                        GamaManager.instance.BoomIndex++;
                        isok = true;
                    }
                    break;

                case ItemObject.Itemtype.Coin:

                    isok = false;
                    GamaManager.instance.TotalPoint += 500;
                    AudioPlay("GetCoin");
                    isok = true;

                    break;
            }
            
            Destroy(collision.gameObject);

        }
    }

    //넉백 시스템
    private void KB()
    {
        if (isKB)
        {
            Rb.velocity = KB_direction * KB_F;
            if (Time.time > KB_EndTime)
            {
                isKB = false;
                Rb.velocity = Vector2.zero;
            }
        }
    }

   
    //플레이어 움직임
    private void PlayerMoving()
    {
        if (!GamaManager.instance.BossDestory && !GamaManager.instance.GameStop)
        {
            float Horizontal = Input.GetAxisRaw("Horizontal");
            float Vertical = Input.GetAxisRaw("Vertical");
            anim.SetInteger("WS", (int)Vertical);

            transform.position += new Vector3(Horizontal, Vertical) * M_Speed * AddSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftShift) && !LShift)
            {
                AddSpeed = 1.5f;
                LShift = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && LShift)
            {
                AddSpeed = 1;
                LShift = false;
            }
        }

        else if (GamaManager.instance.BossDestory)
        {
            EnddingMove();
        }



    }
    private void EnddingMove()
    {
        if (GamaManager.instance.BossDestory)
        {
            gameObject.layer = 3;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(5.4f, 0), 1.5f * Time.deltaTime);
            if (transform.position == new Vector3(5.4f, 0))
            {
                GamaManager.instance.Finale = true;

            }
        }
    }


    
    // 슛
    private void ShootBullet()
    {
        if (!GamaManager.instance.BossDestory && !GamaManager.instance.GameStop)
        {
            CurTime += Time.deltaTime;
            if (CurTime < 0.15f) { return; }

            if (Input.GetButton("Fire1"))
            {
                Shoota();
                AudioPlay("Shoot");
                CurTime = 0;
            }

            if(Input.GetButton("Fire2")&& GamaManager.instance.SuperShotCount > 0 && !SuperShotCount)
            {
                SuperShotCount = true;
               GameObject obj = Instantiate(BulletDataC, BulletStartPoint.position, Quaternion.Euler(0,0,-90), Dynamic);
               Buillet sc = obj.GetComponent<Buillet>();
                sc.SetBullet(30, 15);
                Invoke("SuperShotOk", 1f);
                GamaManager.instance.SuperShotCount--;
            }

            //필살기
            if (Input.GetButton("Jump") && !isBoom && GamaManager.instance.BoomIndex > 0)
            {
                GamaManager.instance.BoomIndex--;
                isBoom = true;

                Instantiate(BoomData, Vector3.zero, Quaternion.identity, Dynamic);

                //Enemy 제거

                EnemyAllDestory();
                BulletDestory();

            }
        }
     }

    private void SuperShotOk()
    {
        SuperShotCount = false;
    }

    private void BulletDestory()
    {
        GameObject[] Bobj = GameObject.FindGameObjectsWithTag("BossBullet");
        for(int i = 0; i < Bobj.Length-1; i++) 
        {
            
            Destroy(Bobj[i].gameObject);
        }
    }

    //맵 적 삭제
    private void EnemyAllDestory()
    {
        GameObject[] FelidEnemeys = GameObject.FindGameObjectsWithTag("Enemey");

        for (int i = 0; i < FelidEnemeys.Length; i++)
        {
            Enermy sc = FelidEnemeys[i].GetComponent<Enermy>();
            sc.HitEnermy(1000);

        }
        //1초 후 폭탄 bool값 복구 (폭탄 못씀)
        Invoke("BoomOk", 1);
    }


    //플레이어 인 카메라
    private void noCAMOUT()
    {
        if (!GamaManager.instance.BossDestory)
        {
            Vector3 m_cam = MainCam.WorldToViewportPoint(transform.position);

            if (m_cam.x < 0.05f) { m_cam.x = 0.05f; }

            if (m_cam.y < 0.05f) { m_cam.y = 0.05f; }
            if (m_cam.x > 0.95f) { m_cam.x = 0.95f; }
            if (m_cam.y > 0.95f) { m_cam.y = 0.95f; }

            transform.position = MainCam.ViewportToWorldPoint(m_cam);
        }
        
    }
         
    

    // 불렛 생성
    private void Shoota()
    {
        switch (GamaManager.instance.CurPower)
        {
            case 0:
                GameObject Ob = Instantiate(BulletDataA, BulletStartPoint.position, Quaternion.Euler(0, 0, -90), Dynamic);
                Buillet bul = Ob.GetComponent<Buillet>();
                bul.SetBullet(ShootDMG, ShootSPD);
                break;

            case 1:
                GameObject Obj = Instantiate(BulletDataB, BulletStartPoint.position, Quaternion.Euler(0, 0, -90), Dynamic);
                Buillet o = Obj.GetComponent<Buillet>();
                 o.SetBullet(2, ShootSPD);
                 
                break;

            case 2:
                GameObject Ob1 = Instantiate(BulletDataD, BulletStartPoint.position, Quaternion.Euler(0, 0, -90), Dynamic);
                Buillet bul1 = Ob1.GetComponent<Buillet>();
                bul1.SetBullet(3, ShootSPD);
              
                break;
        }
    }

    private void BoomOk()
    {
        isBoom = false;
    }


   // 플레이어 피격
    public void OnDamaged()
    {
        
        if(GamaManager.instance.CurHP >  1)
        {
            
            GamaManager.instance.CurHP--;
            
            
            gameObject.layer = 3;
            OnKB(Vector2.left);
            AudioPlay("OnDamged");
            OnMujek();

            //피격시 파워레벨 하락 => (취소) '23.08.18
            //if (GamaManager.instance.CurPower > 0)
            //{
            //    GamaManager.instance.CurPower--;
            //}


        }

        //죽었을때
        else
        {
            Aduio.clip = OnDestory;
            Aduio.Play();

            
            gameObject.SetActive(false);
            hpui.PlayerDestory(false);

            GameObject obj = Instantiate(Boom,transform.position, Quaternion.identity, Dynamic);
            Explsion exp = obj.GetComponent<Explsion>();
            exp.SetScale(Sr.sprite.rect.width);
            GamaManager.instance.CurLife--;

            //사망 리스폰
            if (GamaManager.instance.CurLife > 0)
            {
                
                GamaManager.instance.CurPower = 0;
                Invoke("ReSpawnPlayer", 1);
                                
            }
            else
            {
                hpui.PlayerDestory(false);
                GamaManager.instance.PlayerGameOver = true;
                GamaManager.instance.GameOver();
            }
        }
    }

    
    

    //리스폰
    void ReSpawnPlayer()
    {
        gameObject.SetActive(true);
        hpui.PlayerDestory(true);
        transform.position = new Vector3(-5.5f, 0, 0);
        GamaManager.instance.CurHP = 3;
        OnMujek();
        isPlayerDead = true;

    }


   
    // 넉백
    void OnKB(Vector2 direction)
    {
        if (!isKB)
        {
            isKB = true;
            KB_direction = direction.normalized;
            KB_EndTime = Time.time + KB_D;

        }
    }


    // 피격 무적해제
    void OnMujek()
    {
        CurTime += Time.deltaTime;

        gameObject.layer = LayerMask.NameToLayer("OnDamaged");
        Sr.color = new Color(1, 1, 1, 0.4f);

        //무적시간 2초로 늘림
        Invoke("OffMujek",2f);

    }
    void OffMujek()
    {
        Sr.color = new Color(1, 1, 1, 1);
        gameObject.layer = LayerMask.NameToLayer("Player");
        CurTime = 0;
    }


    // 음악 재생
    public void AudioPlay(string _sValue)
    {
        switch( _sValue )
        {
            case "Shoot":
                Aduio.clip = Shoot;
                Aduio.Play();
                break;

            case "OnDamged":
                Aduio.clip = OnDamged;
                Aduio.Play();
                break;

            case "Destory":
                Aduio.clip = OnDestory;
                Aduio.Play();
                break;

            case "BossSpawn":
                Aduio.clip = BossSpawn;
                Aduio.Play();
                break;

            case "BossSound":
                Aduio.clip = BossSound;
                Aduio.Play();
                break;

            case "GetItem":
                Aduio.clip = GetPowerBooM;
                Aduio.Play();
                break;

            case "GetCoin":
                Aduio.clip = GetCoin;
                Aduio.Play();
                break;




        }

    }
}
