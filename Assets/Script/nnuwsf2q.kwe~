using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    private float BossSpeed ;
    [SerializeField] Sprite Idle;
    [SerializeField] Sprite OnDamaged;
    [SerializeField] GameObject Exlpo;
    
    SpriteRenderer BossSr;


    bool BossProduction = false;
    bool BossProduction2 = false;
    bool BossProduction3 = false;
    public bool BossAction = false;

    //사운드
    [SerializeField] AudioClip Sound;
    bool isPhase2;
    bool isPhase3;


    //BossBullet
    [SerializeField] GameObject BossBullet;
    [SerializeField] GameObject BossBullet2;
    float BulletTimer;
    Vector3 BossPo;
    GameObject dynamic;

    //1페이즈
    [SerializeField] bool Phase1;
    float Hping;
    float Vping;
    Vector3 BossMove1;

    //2페이즈
    [SerializeField] bool Phase2;

    //3페이즈
    [SerializeField] bool Phase3;
    Vector3 BossMove3 = new Vector3(-2, -2);

    //죽음
   public bool BossDead;
    GameObject GM;
    Transform BoomPoint0;
    Transform BoomPoint1;
    Transform BoomPoint2;
    Transform BoomPoint3;
    Transform BoomPoint4;
    Transform BoomPoint5;
    List<Vector3> BPLIST;
    float BoomTimer;
    float BoomEnd;

    

    AudioSource BossAudio;

    //참조
    
    Player player;
    Transform Player_Tr;
    Vector3 FistMove = new Vector3(-0.2f, 0);

    private void Awake()
    {
        BossSpeed = 30;
        player = GameObject.FindAnyObjectByType<Player>();
        Player_Tr =player.GetComponent<Transform>();
        GamaManager.instance.BackGroundChangeOk = true;
        BossAudio = GetComponent<AudioSource>();
        BossAudio.Play();
        BossSr = GetComponent<SpriteRenderer>();
        
        dynamic = GameObject.Find("Dynamic");

        GM = GameObject.Find("GameManager");
        BoomPoint0 = GM.transform.GetChild(3).GetChild(0).GetComponent<Transform>();
        BoomPoint1 = GM.transform.GetChild(3).GetChild(1).GetComponent<Transform>();
        BoomPoint2 = GM.transform.GetChild(3).GetChild(2).GetComponent<Transform>();
        BoomPoint3 = GM.transform.GetChild(3).GetChild(3).GetComponent<Transform>();
        BoomPoint4 = GM.transform.GetChild(3).GetChild(4).GetComponent<Transform>();
        BoomPoint5 = GM.transform.GetChild(3).GetChild(5).GetComponent<Transform>();

        Vector3 BP1 = BoomPoint0.transform.position;
        Vector3 BP2 = BoomPoint1.transform.position;
        Vector3 BP3 = BoomPoint2.transform.position;
        Vector3 BP4 = BoomPoint3.transform.position;
        Vector3 BP5 = BoomPoint4.transform.position;
        Vector3 BP6 = BoomPoint5.transform.position;

        BPLIST = new List<Vector3>();
        BPLIST.Add(BP1);
        BPLIST.Add(BP2);
        BPLIST.Add(BP3);
        BPLIST.Add(BP4);
        BPLIST.Add(BP5);
        BPLIST.Add(BP6);
        //player.AudioPlay("BossSpawn");
    }
    //체력 스피드 ok
    //보스 리스폰 ok

    //연출 등장하면서 조무래기를 다 부시면서 들어옴 ok
    //제자리가서 우와! 하면 쫄 다부서짐 ing
    //이때 캐릭터는 움직일수없음

    //보스움직임
    //미사일

    void Update()
    {
        Move();
        BossOpenningMove();
        BossDestoryAllEnermy();
        BossAttack();
        BossEnd();
               
    }

   
    private void Move()
    { 
        if (!BossProduction)
        {    
            transform.position += FistMove * BossSpeed * Time.deltaTime;
        }

        if(Phase1 && !Phase2 && !Phase3)
        {
            Vping = Mathf.PingPong(Time.time * 1.5f, 3f) -1.5f;
            BossMove1 = new Vector3(0, Vping);

            transform.position += BossMove1 * 1 *Time.deltaTime;

        }
        else if (!Phase1 && Phase2 && !Phase3)
        {
             
            Hping = Mathf.PingPong(Time.time * 0.5f, 2f) - 1f;
            Vping = Mathf.PingPong(Time.time * 1.5f, 3f) - 1.5f;
            BossMove1 = new Vector3(Hping, Vping);

            transform.position += BossMove1 * 1 * Time.deltaTime;

        }
        else if (!Phase1 && !Phase2 && Phase3 && !GamaManager.instance.BossDead)
        {
            
            Vector3 CurrentPos = Camera.main.WorldToViewportPoint(transform.position);

            if (CurrentPos.x < 0.02f && BossMove3.x < 0)
            {
                BossMove3 = Vector3.Reflect(BossMove3, Vector3.left);
            }
            else if (CurrentPos.x > 0.99f && BossMove3.x > 0)
            {
                BossMove3 = Vector3.Reflect(BossMove3, Vector3.right);
            }

            else if (CurrentPos.y < 0.02f && BossMove3.y < 0)
            {
                BossMove3 = Vector3.Reflect(BossMove3, Vector3.down);
            }
            else if (CurrentPos.y > 0.99f && BossMove3.y > 0)
            {
                BossMove3 = Vector3.Reflect(BossMove3, Vector3.up);
            }

            transform.position += BossMove3 * 1.5f * Time.deltaTime;
        }

        else if (GamaManager.instance.BossDead && !BossDead)
        {
            Vector3 vec = new Vector3(1.2f, 0.2f);
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, vec, 3 * Time.deltaTime);

            if(gameObject.layer == 9)
            {
                gameObject.layer = 11;
            }
        }
        
        if(transform.position == new Vector3(1.2f, 0.2f))
        {
            BossDead = true;
        }
    }

   
    private void BossEnd()
    {
        float rand = Random.Range(0,BPLIST.Count-1);
        BoomTimer += Time.deltaTime;
        if (BossDead)
        {
            BoomEnd += Time.deltaTime;

        if (BoomEnd < 5 && BossDead)
        {
            if (BossDead && BoomTimer > 0.2f)
            {
                Instantiate(Exlpo, BPLIST[(int)rand], Quaternion.identity, dynamic.transform);
                BoomTimer = 0;
            }
        }
        if(BoomEnd > 3 && BossDead)
        {
            GamaManager.instance.BossDestory = true;
            Destroy(gameObject);
            GameObject ob = Instantiate(Exlpo, transform.position, Quaternion.identity,dynamic.transform);
            Explsion obj = ob.GetComponent<Explsion>();
            obj.SetScale(BossSr.sprite.rect.width);
            
        }
        }
    }

    private void BossAttack()
    {
        BulletTimer += Time.deltaTime;
        BossPo = transform.position + new Vector3(-1, 0);

        if (Phase1 && !Phase2 && !Phase3)
        {
            if(BulletTimer > 0.7f)
            {
                //100%유도미사일 로직
                //Instantiate(BossBullet2, BossPo,Quaternion.identity);

                float Q_z = Quaternion.FromToRotation(Vector3.right, transform.position - Player_Tr.position).eulerAngles.z;
                Instantiate(BossBullet, BossPo + new Vector3(0,+0.4f), Quaternion.Euler(0, 0, Q_z), dynamic.transform);
                Instantiate(BossBullet, BossPo + new Vector3(0, -0.4f), Quaternion.Euler(0, 0, Q_z), dynamic.transform);
                BulletTimer = 0;
            }
            
        }
        else if (!Phase1 && Phase2 && !Phase3)
        {
            if (BulletTimer > 0.5f)
            {
                Instantiate(BossBullet, BossPo, Quaternion.identity, dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, 20), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, 40), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, -20), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, -40), dynamic.transform);
                BulletTimer = 0;
            }
              
        }
        else if (!Phase1 && !Phase2 && Phase3 && !GamaManager.instance.BossDead)
        {
            if (BulletTimer > 0.4f)
            {
                Instantiate(BossBullet, BossPo, Quaternion.identity, dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, 40), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, -40), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, -90), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0,  90), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, -140), dynamic.transform);
                Instantiate(BossBullet, BossPo, Quaternion.Euler(0, 0, -200), dynamic.transform);
                BulletTimer = 0;
            }
        }
               
    }

    //액션 1
    private void BossOpenningMove()
    {
        

        if (transform.position.x < -3 && !BossProduction)
        {
            FistMove = Vector3.Reflect(FistMove, Vector3.left);

            if(transform.position.x < -2.9)
            {
                BossProduction2 = true;
            }
        }

        if(transform.position.x >= 1.8f && BossProduction2)
        {
            
            BossProduction = true;

            if (transform.position.x >= 1.65f)
            {
                Invoke("P1", 1);
                BossProduction3 = true;
                BossProduction2 = false;
                GamaManager.instance.HelpmeBossSc = true;
            }
        }
    }

    void P1()
    {
        Phase1 = true;
    }
    //액션 2
    private void BossDestoryAllEnermy()
    {
        if (BossProduction3)
        {
            BossProduction3 = false;
            BossAction = true;

            BossAudio.clip = Sound;
            BossAudio.Play();
            
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemey");
            for (int i = 0; i < obj.Length; i++)
            {
                Enermy sc = obj[i].GetComponent<Enermy>();
                sc.HitEnermy(100);
            }
            GameObject[] obj2 = GameObject.FindGameObjectsWithTag("Item");
            for (int i = 0; i < obj2.Length; i++)
            {
                Destroy(obj2[i].gameObject);
            }
        }
    }


    public void HitBoss(float _DMG)
    {
        GamaManager.instance.BossCurHP -= _DMG;
        BossSr.sprite = OnDamaged;
        Invoke("ReturnSprite", 1f);


       
        if (GamaManager.instance.BossPhase == 2 && !isPhase2)
        {
            isPhase2 = true;

            Phase1 = false;
            Phase2 = true;

            BossAudio.Play();
        }

        else if (GamaManager.instance.BossPhase == 3 && !isPhase3)
        {
           
            isPhase3 = true;

            Phase1 = false;
            Phase2 = false;
            Phase3 = true;

            BossAudio.Play();
        }

        // HP 0 되면 폭파 이펙트 폭파
    }

    private void ReturnSprite()
    {
        BossSr.sprite = Idle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Enermy sc = collision.gameObject.GetComponent<Enermy>();
            sc.HitEnermy(1000);
        }
       
        if (collision.gameObject.layer == 6)
        {
                Player sc = collision.gameObject.GetComponent<Player>();
                sc.OnDamaged();
                
        }
        

    }

   }
