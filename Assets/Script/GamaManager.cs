using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class RankData
{
    public int Score;
    public string Name;
}

public enum SceneType
{
    PlayScene,
    MainScene
}

public class GamaManager : MonoBehaviour
{
    public static GamaManager instance;
  
   
    [SerializeField] float SpawnTime = 2.0f;

    [SerializeField] public int CurHP;
    [SerializeField] public int MaxHP;
    [SerializeField] public int CurPower;
    [SerializeField] public float CurLife;
    [SerializeField] public float MAXLife;
    [SerializeField] public int BoomIndex;
    [SerializeField] List<GameObject> Enemy_List;
    [SerializeField] GameObject BossObject;
    [SerializeField] public float BossCurHP;
    [SerializeField] public float BossMaxHP;
    [SerializeField] public int BossPhase;
        
    [SerializeField] private Transform Dynamic;
    [Header("점수")]
    [SerializeField] public Text point;
    [SerializeField] public int TotalPoint;
    [SerializeField] List<GameObject> Cloud_List;

    // 230823 작성
    [Header("랭킹시스템")]
    [SerializeField] private TMP_InputField ipfGameOverName;
    [SerializeField] private TMP_Text TextGameOverRank;
    [SerializeField] private Button btnGameOver;
    public bool PlayerGameOver;

    private List<RankData> RankList = new List<RankData>();//등수
    private string RankKey = "Rankkey";
    private string RankKeyisNull = "AAA";
    private int RankCount = 10; //등수갯수
  
    //private int score = 0;
    //public int Score
    //{
    //    get
    //    {
    //        //디자인패턴화했음 , 변수의 프로퍼티
    //        Debug.Log("스코어를 호출햇음");
    //        return score;
    //    }
    //    set
    //    {
    //        Debug.Log("스코어를 넣었음");
    //        score = value;
    //    }
    //}



    Transform SpawnPosition;
    List<Transform> CloudSpawnP = new List<Transform>();

    public AudioClip Normal;
    public AudioClip BoosMode;
    AudioSource Audio;

    public float OpenTimer;
    float Timer;
    float CloudTimer;
    float CurTime;
    bool BossMode;
    public bool BossDead;

    //중요 연결 스위치 보스팝업후
    public bool HelpmeBossSc;
    public bool BackGroundChangeOk;
    public bool BossDestory;
    public bool Finale;
    public bool GameStop;

    //KillCountUi관련 변수
    public float Killcount;
    public int SuperShotCount;

    private void Awake()
    {
        

        MaxHP = 5;
        CurHP = 5;
        CurLife = 4;
        MAXLife = 4;
        BoomIndex = 3;
        BossCurHP = 650;
        BossMaxHP = 650;
        Killcount = 0;
        SuperShotCount = 0;
        Audio = GetComponent<AudioSource>();
        SpawnPosition = transform.GetChild(0);
        CloudSpawnP.Add(transform.GetChild(1).GetComponent<Transform>());
        CloudSpawnP.Add(transform.GetChild(2).GetComponent<Transform>());

        //지워도되요
        ipfGameOverName.gameObject.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        GetRankDatas();
    }


    //랭크 가져오는 함수
    private void GetRankDatas()
    {
        //게임실행시 메모리에 저장된 랭크 데이터를 불러와서 RankList에 Awake에서 초기화시킴, << string.Empty == " 공백" >>

        string Value = PlayerPrefs.GetString(RankKey, string.Empty); 

       if(Value == string.Empty)
        {
            for(int i = 0;   i < RankCount;  i++)
            {
                RankData data = new RankData();
                data.Name = RankKeyisNull;
                data.Score = 0;
                RankList.Add(data);
            }
            Value = JsonConvert.SerializeObject(RankList);
            PlayerPrefs.SetString(RankKey, Value);
        }
        else
        {
            RankList = JsonConvert.DeserializeObject<List<RankData >>(Value);
                        
        } 
    }

    void Update()
    {
        SS();
        SpawnCloud();
        BossPhaseChager();
        KillCountOP();
    }

    // 10킬 하면  슈퍼샷 충전
    private void KillCountOP()
    {
        if (Killcount >= 10)
        {
            Killcount = 0;

            if(SuperShotCount < 3)
            {
                SuperShotCount++;
            }
            
        }
    }
    public void isAudio(string _Value)
    {
        if(_Value == "Play")
        {
            Audio.Play();
        }

        else if (_Value == "Pause")
        {
            Audio.Pause();
        }
       
    }

    // 시간대비 스폰 타이머
    private void SS()
    {
        CurTime += Time.deltaTime;
        if(CurTime < 10 && !BossMode)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.7f)
            {
                Timer = 0;
                EnemySpawn();
            }
        }
        else if(CurTime < 20 && !BossMode)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.5f)
            {
                Timer = 0;
                EnemySpawn();
            }
        }
        else if(CurTime < 30 && !BossMode)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.3f)
            {
                Timer = 0;
                EnemySpawn();
            }
        }
        else if (CurTime < 40 && !BossMode)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.2f)
            {
                Timer = 0;
                EnemySpawn();
            }
        }
        else if (CurTime < 50 && !BossMode)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.1f)
            {
                Timer = 0;
                EnemySpawn();
            }
        }
        else if (CurTime > 50 && !BossMode)
        {
            BossMode = true;
            BossSpawnTime();
        }

    }
    //void Sapwn()
    //{
    //    Timer += Time.deltaTime;
    //    if(Timer > SpawnTime)
    //    {
    //        Timer = 0;
    //        EnemySpawn();
    //    }
    //}

    void BossPhaseChager()
    {
        if(BossCurHP > 376) 
        {
            BossPhase = 1;
        }
        if (BossCurHP > 151 && BossCurHP <=375)
        {
            BossPhase = 2;
        }
        if(BossCurHP <= 150 && BossCurHP > 1)
        {
            BossPhase = 3;
        }
        if(BossCurHP <= 0)
        {
            BossDead = true;
        }

    }
    void EnemySpawn()
    {
        int Random_Object = Random.Range(0, Enemy_List.Count);
        GameObject Emeny_Object = Enemy_List[Random_Object];

        float Random_y = Random.Range(-2.5f, 3f);

        Vector3 Spawn = SpawnPosition.position;
        Spawn.y = Random_y;
        
        GameObject obj = Instantiate(Emeny_Object, Spawn, Quaternion.Euler(0,0,-90), Dynamic.transform);
        Enermy sc = obj.gameObject.GetComponent<Enermy>();
        float Rate = Random.Range(0f, 100f);

       if(Rate < 15f)
        {
            sc.HaveItemSapwn();
        }

      
            
        
    }
    void SpawnCloud()
    {
         CloudTimer += Time.deltaTime;
         if(CloudTimer > 10)
        {
            CloudSpawnReddy();
            CloudTimer = 0;
        }

    }
    void CloudSpawnReddy()
    {
        float CloudType = Random.Range(0,Cloud_List.Count);
        Vector3 CloudPoint = CloudSpawnP[Random.Range(0,CloudSpawnP.Count)].position;

        Instantiate(Cloud_List[(int)CloudType], CloudPoint, Quaternion.identity,Dynamic.transform);
    }

  private void BossSpawnTime()
    {  
        Vector3 spwn = SpawnPosition.position;
        GameObject obj = Instantiate(BossObject,spwn, Quaternion.Euler(0,0,-90),Dynamic.transform);

    }

    public void BoosModeBGM()
    {
        Audio.clip = BoosMode;
        Audio.Play();
        Audio.volume = 0.8f;
    }

    public void GameOver()
    {
        if (!PlayerGameOver)
        {
            return;
        }
        //몇등인지 체크해주는시스템
        int rank = F_GetMyRank(TotalPoint);
        if (rank == -1)
        {
            TextGameOverRank.text = $"당신은 랭킹밖의 점수입니다.";
        }
        else
        {
            TextGameOverRank.text = $"당신의 랭크는 {rank}등 입니다.";
        }

        
        ipfGameOverName.gameObject.SetActive(true);


        //버튼 클릭하면 메인씬으로 이동하게 해야함
        btnGameOver.gameObject.SetActive(true);
        btnGameOver.onClick.AddListener( () => { F_OnBtnClick(); });
       

    }
    private void F_OnBtnClick()
    {
        string ipfText = string.Empty;
        ipfText = ipfGameOverName.text;

        if (ipfText.Length < 3)
        {
            TextGameOverRank.text = $"3글자 이상 이름을 입력하세요";
        }
        else if(ipfText.Length >= 3) 
        {            
            int Rank = F_GetMyRank(TotalPoint);
            F_SetMyRank(ipfText, TotalPoint, Rank);

            //직렬화 후 저장
            string Value = JsonConvert.SerializeObject(RankList);
            PlayerPrefs.SetString(RankKey, Value);

            //로드 씬
            SceneManager.LoadScene((int)SceneType.MainScene);
        }
        
    }
    private int F_GetMyRank(int _TotalPoint)
    {
        int result = -1;

        for (int i = 0; i < RankCount; i++)
        {
            if (_TotalPoint > RankList[i].Score)
            {
                return i+1;
            }
        }
        
        // 보통 null이거나 해당되지않으면 -1으로 표기함
        return result;
        
    }

    private void F_SetMyRank(string _PlayName, int _MyPoint , int _Rank)
    {
        _Rank = _Rank - 1;

        RankList.Insert(_Rank, new RankData() { Name = _PlayName, Score = _MyPoint });
        RankList.RemoveAt(RankCount);

    }
}
