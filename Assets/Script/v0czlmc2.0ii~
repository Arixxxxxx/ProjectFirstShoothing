using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    private Image HpUi1;
    private Image HpUi2;
    private Image HpUi3;
    private TextMeshProUGUI TotalPoint;
    private TextMeshProUGUI BoomIndex;

    private Image Power1;
    private TextMeshProUGUI Power_T1;

    private Image Power2;
    private TextMeshProUGUI Power_T2;

    private Image Power3;
    private TextMeshProUGUI Power_T3;

    private TextMeshProUGUI Timer;
    float Timers;

    private Image RspawnBack;
    private Image RspawnFront;
    private Image RspawnFrontin;

    private TextMeshProUGUI LevelText;

    private GameObject SpawnBar;
    // PowerShot
    Transform PowerBarUi;
    private Image KillCountUi;
    private TextMeshProUGUI KillCountText;
    private TextMeshProUGUI ReadyText;
    Animator Ani;
    Animator AniOutLine;

    //시작부분
    private Image StarBox;
    private TextMeshProUGUI StarCount;
    public float startTimer;
    bool isok;
    bool timerstart;
    bool GameStartStartUiOff;
    public float SSTImer;
    public AudioClip warning;
    public AudioClip StarCountAudio;
    private int Audiocounter;
    bool Audkook;

    //esc부분
    private Transform Option;
    private Transform F1;

    //보스경고
    private Image BossSoon;
    private float Curtime;
    private float SCCurtime;
    AudioSource Audio;
    bool isAudioPlay;

    
    bool BossImagePop;
    //보스스 지지직 이펙트
    private Image BossEffect;
    private float Curtime1;
    //보스 피통바
    private Transform BossHpBar;
    private TextMeshProUGUI BossBarText;

    //엔딩커튼
    private Image EnddingCutten;
    private TextMeshProUGUI EnddingText;
    private Transform ResterButten;
    private Transform ExitButten;
    




    private void Awake()
    {
        
        HpUi1 = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        HpUi2 = transform.GetChild(0).GetChild(2).GetComponent<Image>();
        HpUi3 = transform.GetChild(0).GetChild(3).GetComponent<Image>();
        TotalPoint = transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>();
        BoomIndex = transform.GetChild(0).GetChild(7).GetComponent<TextMeshProUGUI>();

        Power1 = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        Power2 = transform.GetChild(1).GetChild(1).GetComponent<Image>();
        Power3 = transform.GetChild(1).GetChild(2).GetComponent<Image>();

        Power_T1 = transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>();
        Power_T2 = transform.GetChild(1).GetChild(4).GetComponent<TextMeshProUGUI>();
        Power_T3 = transform.GetChild(1).GetChild(5).GetComponent<TextMeshProUGUI>();

        Timer = transform.GetChild(0).GetChild(8).GetComponent<TextMeshProUGUI>();

        SpawnBar = transform.GetChild(2).GetComponent <GameObject>();
        RspawnBack = transform.GetChild(2).GetChild(0).GetComponent<Image>();
        RspawnFront = transform.GetChild(2).GetChild(1).GetComponent<Image>();
        RspawnFrontin = transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>();
        LevelText = transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();

        Option = transform.GetChild(3).GetComponent<Transform>();
        F1 = transform.GetChild(4).GetComponent<Transform>();
        StarBox = transform.GetChild(4).GetChild(2).GetComponent< Image > ();
        StarCount = transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();

        BossSoon = transform.GetChild(5).GetComponent<Image>();

        BossEffect = transform.GetChild(6).GetComponent<Image>();

        BossHpBar = transform.GetChild(7).GetComponent <Transform>();
        BossBarText = transform.GetChild(7).GetChild(3).GetComponent<TextMeshProUGUI>();

        EnddingCutten = transform.GetChild(8).GetComponent<Image>();
        EnddingText = transform.GetChild(8).GetChild(0).GetComponent <TextMeshProUGUI>();

        ResterButten = transform.GetChild(8).GetChild(1).GetComponent<Transform>();
        ExitButten = transform.GetChild(8).GetChild(2).GetComponent<Transform>();

        PowerBarUi = transform.GetChild(9).GetComponent<Transform>();
        KillCountUi = transform.GetChild(9).GetChild(1).GetComponent<Image>();
        KillCountText = transform.GetChild(9).GetChild(0).GetComponent<TextMeshProUGUI>();
        ReadyText = transform.GetChild(9).GetChild(2).GetComponent<TextMeshProUGUI>();
        Audio = GetComponent<AudioSource>();
        startTimer = 5;

        //시작 도움말화면 active             
        //F1.gameObject.SetActive(true);
        Ani = transform.GetChild(9).GetChild(2).GetComponent<Animator>();
        AniOutLine = transform.GetChild(9).GetChild(4).GetComponent<Animator>();
    }
    
    void Update()
    {
        GameStart();
        TimeUI();
        PowerUI();
        HpuiOnOff();
        TotalPointView();
        ReSpawnBarUI();
        ESCKEY();
        BossImagePopUp();
        BossEffecShow();
        BossHpBarText();
        Endding();
        GameCount();
        KillCountUiFuntion();
        UiOff();
    }

    private void UiOff()
    {
        if (GamaManager.instance.BossDestory)
        {
            PowerBarUi.gameObject.SetActive(false);
        }
    }

    //게임시작 화면 제어
    private void GameStart()
    {
        if (F1.gameObject.activeSelf && !isok)
        {
            isok = true;
            GamaManager.instance.isAudio("Pause");
            Time.timeScale = 0f;
        } 
                
        if (F1.gameObject.activeSelf && !StarBox.gameObject.activeSelf && Input.anyKeyDown)
        {
            StarBox.gameObject.SetActive(true);
            timerstart = true;

        }
    }


    private void GameCount()
    {
        if (timerstart)
        {
                startTimer -= Time.unscaledDeltaTime;
                StarCount.text = (startTimer).ToString("F0");
           if(startTimer > 4.0f && startTimer < 4.03f)
            {
                Audio.clip = StarCountAudio;
                Audio.Play();
            }
           else if (startTimer > 3.0f && startTimer < 3.03f)
            {
                Audio.clip = StarCountAudio;
                Audio.Play();
            }
            else if (startTimer > 2.0f && startTimer < 2.03f)
            {
                Audio.clip = StarCountAudio;
                Audio.Play();
            }
            else if (startTimer > 1.0f && startTimer < 1.03f)
            {
                Audio.clip = StarCountAudio;
                Audio.Play();
              
            }


            if (startTimer < 0 && !GameStartStartUiOff)
            {
                Audio.clip = StarCountAudio;
                Audio.Play();
                F1.gameObject.SetActive(false);
                Time.timeScale = 1f;


                GamaManager.instance.isAudio("Play");
                GameStartStartUiOff = true;
                KillCountText.gameObject.SetActive(true);
                KillCountUi.gameObject.SetActive(true);
                PowerBarUi.gameObject.SetActive(true);
            }
        }
    }
    //슈퍼샷 Ui관련

    private void KillCountUiFuntion()
    {
        if (GamaManager.instance.SuperShotCount > 0)
        {
            ReadyText.gameObject.SetActive(true);
            AniOutLine.gameObject.SetActive(true);
            AniOutLine.SetBool("Ok", true);
            Ani.SetBool("Ok", true);
        }
        else if(GamaManager.instance.SuperShotCount == 0)
        {
            ReadyText.gameObject.SetActive(false);
            Ani.SetBool("Ok", false) ;
            AniOutLine.SetBool("Ok", false);
            AniOutLine.gameObject.SetActive(false);
        }
        if (GamaManager.instance.SuperShotCount  == 3)
        {
            KillCountUi.fillAmount = 1;
        }

        else if (GamaManager.instance.SuperShotCount < 3)
        {
            KillCountUi.fillAmount = GamaManager.instance.Killcount / 10;
        }
          
          KillCountText.text = GamaManager.instance.SuperShotCount.ToString();
             
    }
    
    //엔딩포인트
    private void Endding()
    {
        if (GamaManager.instance.Finale)
        {
            Color co = EnddingCutten.color;
            co.a += 0.2f * Time.deltaTime;
            EnddingCutten.color = co;

            if(co.a >= 0.95f)
            {
                Color cs = EnddingText.color;
                cs.a += 0.25f * Time.deltaTime;
                EnddingText.color = cs;
                
                if(cs.a >= 0.95f)
                {
                    ResterButten.gameObject.SetActive(true);
                    ExitButten.gameObject.SetActive(true);
                }
            }
        }
        

        
    }
    //오프닝 이벤트
    private void BossEffecShow()
    {
        
        if (GamaManager.instance.HelpmeBossSc == true)
        {
            Curtime1 += Time.deltaTime;
            BossEffect.fillAmount += 0.33f * Time.deltaTime * 8;

            if (Curtime1 > 1)
            {
                BossEffect.gameObject.SetActive(false);

                if (!BossHpBar.gameObject.activeSelf && !GamaManager.instance.BossDestory)
                {
                    Timer.gameObject.SetActive(false);
                    BossHpBar.gameObject.SetActive (true);
                }
            }
        }
        
    }

    //보스 피통바 텍스트
    private void BossHpBarText()
    {
        BossBarText.text = $"{GamaManager.instance.BossCurHP} / {GamaManager.instance.BossMaxHP} / {GamaManager.instance.BossPhase} Phase ";
    }

    //보스 팝업 경고문
    private void BossImagePopUp()
    {
        if (BossImagePop)
        {
            if (!isAudioPlay)
            {
                isAudioPlay = true;
                Audio.clip = warning;
                Audio.Play();
            }
            

            BossSoon.gameObject.SetActive(true);
            
            Curtime += Time.deltaTime;

            // 팝업 경고문 이펙트 활성시간
            if( Curtime < 3f)
            {
                SCCurtime += Time.deltaTime;
                
                if (SCCurtime < 0.5)
                {
                    BossSoon.transform.localScale += new Vector3(0.1f, 0, 1f) * Time.deltaTime;

                    Color cc = BossSoon.color;
                    cc.a -= 1f * Time.deltaTime;
                    BossSoon.color = cc;
                }
                else if(SCCurtime > 0.5 && SCCurtime < 1)
                {
                    BossSoon.transform.localScale -= new Vector3(0.1f, 0, 1f) * Time.deltaTime;
                    
                    Color cc = BossSoon.color;
                    cc.a += 1f * Time.deltaTime;
                    BossSoon.color = cc;
                    if (SCCurtime > 0.95f)
                    {
                        SCCurtime = 0;
                    }
                }
               
            }

            //팝업 이펙트 종료 시간
            else if(Curtime > 3.1f)
            {
                BossSoon.gameObject.SetActive(false);
                BossImagePop = false;

            }
        }
    }

    
    // ESC 및 F1 UI
    private void ESCKEY()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GamaManager.instance.GameStop )
        {
            GamaManager.instance.isAudio("Pause");
            Time.timeScale = 0f;
            Option.gameObject.SetActive(true);
            GamaManager.instance.GameStop = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && GamaManager.instance.GameStop && Option.gameObject.activeSelf == true)
        {
            Time.timeScale = 1f;
            Option.gameObject.SetActive(false);
            GamaManager.instance.GameStop = false;
            GamaManager.instance.isAudio("Play");
        }
        //if (Input.GetKeyDown(KeyCode.F1) && !Gamestop && Option.gameObject.activeSelf == false )
        //{
        //    Time.timeScale = 0f;
        //    F1.gameObject.SetActive(true);
        //    Gamestop = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Escape) && F1.gameObject.activeSelf == true && Gamestop)
        //{
        //    Time.timeScale = 1f;
        //    F1.gameObject.SetActive(false);
        //    Gamestop = false;
        //}
    }

    // 옵션 계속하기 및 종료
    public void KeepGoing() 
    {
        Time.timeScale = 1f;
        Option.gameObject.SetActive(false);
        GamaManager.instance.GameStop = false; ;
    }

    public void QuieGame()
    {
        Application.Quit();
    }

    public void RestatGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // 우측 하단바 
    private void ReSpawnBarUI()
    {
        RspawnFront.fillAmount = Time.time / 50;

        if (RspawnFront.fillAmount > 0.2f && RspawnFront.fillAmount < 0.39f)
        {
            
            RspawnFrontin.color = new Color(1, 0.8f, 0, 1);
            LevelText.text = "2단계";
        }
        else if (RspawnFront.fillAmount > 0.4f && RspawnFront.fillAmount < 0.59f)
        {
            RspawnFrontin.color = new Color(1, 0.6f, 0, 1);
            LevelText.text = "3단계";
        }
        else if (RspawnFront.fillAmount > 0.6f && RspawnFront.fillAmount < 0.79f)
        {
            RspawnFrontin.color = new Color(1, 0.4f, 0, 1);
            LevelText.text = "4단계";
        }
        else if (RspawnFront.fillAmount > 0.8f && RspawnFront.fillAmount < 0.99f)
        {
            RspawnFrontin.color = new Color(1, 0.2f, 0, 1);
            LevelText.text = "5단계";
            
        }
        if (RspawnFront.fillAmount > 0.88f && RspawnFront.fillAmount < 0.99f)
        {
            BossImagePop = true;
        }
            if (RspawnFront.fillAmount == 1)
        {
            RspawnFrontin.color = new Color(1, 0, 0, 1);
            LevelText.text = "BOSS";
        }
        
    }

    // 상단 전투시간알림
    private void TimeUI()
    {
        Timers += Time.deltaTime;
        Timer.text = $"<color=red>{(51-Timers).ToString("F0")}</color> 후 BOSS 출동!";
    }
    private void PowerUI()
    {
        switch (GamaManager.instance.CurPower)
        {
            case 0:
               
                Power2.color = new Color(1f,1f,1f,0.1f);
                Power_T2.gameObject.SetActive(false);

                Power3.color = new Color(1f, 1f, 1f, 0.1f);
                Power_T3.gameObject.SetActive(false);
                break;

            case 1:
              
                Power_T1.gameObject.SetActive(false);

                Power2.color = new Color(1f, 1f, 1f,1f);
                Power_T2.gameObject.SetActive(true);

                Power3.color = new Color(1f, 1f, 1f, 0.1f);
                Power_T3.gameObject.SetActive(false);

                break;

            case 2:
                Power1.gameObject.SetActive(true);
                Power_T1.gameObject.SetActive(false);

                Power2.color = new Color(1f, 1f, 1f,1f);
                Power_T2.gameObject.SetActive(false);

                Power3.gameObject.SetActive(true);
                Power3.color = new Color(1f, 1f, 1f,1f);
                Power_T3.gameObject.SetActive(true);
                break;

        }
    }
    // LIFE 갯수
    private void HpuiOnOff()
    {
        switch (GamaManager.instance.CurLife)
        {
          
                case 4:
                HpUi1.gameObject.SetActive(true);
                HpUi2.gameObject.SetActive(true);
                HpUi3.gameObject.SetActive(true);
                break;

                case 3:
                HpUi1.gameObject.SetActive(true);
                HpUi2.gameObject.SetActive(true);
                HpUi3.gameObject.SetActive(false);
                break;

                case 2:
                HpUi1.gameObject.SetActive(true);
                HpUi2.gameObject.SetActive(false);
                HpUi3.gameObject.SetActive(false);
                break;

                case 1:
                HpUi1.gameObject.SetActive(false);
                HpUi2.gameObject.SetActive(false);
                HpUi3.gameObject.SetActive(false);
                break;
        }
    }

    //토탈포인트
    private void TotalPointView()
    {
        TotalPoint.text = GamaManager.instance.TotalPoint.ToString("D6");
        BoomIndex.text = GamaManager.instance.BoomIndex.ToString();
    }
}
