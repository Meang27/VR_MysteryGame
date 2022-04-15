using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Talking3 : MonoBehaviour
{
    [Header("Player")]
    public GameObject player; //텍스트 박스 이미지
    public GameObject AG; //아지 텍스트 박스
    public GameObject AR; //아리 텍스트 박스
    public GameObject Ch; //선택창
    public GameObject AC1; //설명창
    public GameObject P; //화살표
    public GameObject T1; //증거1
    public GameObject T2; //증거2
    public GameObject CA; //카메라 화면 이미지
    public GameObject C_2;  //2
    public GameObject C_1;  //1
    public GameObject CC; //카메라 이미지
    public GameObject BB; //조준점
    public GameObject coin; //코인생성
    public GameObject ARC; //아리캐릭터
    public GameObject TT1; //증거물 위치1
    public GameObject TT2;  //증거물 위치2
    public GameObject img; //스샷 이미지
    //public GameObject[] anything; ->게임 오브젝트의 배열 모든 오브젝트나 코드부분에서 배열로 생성해 cpu랑 작업 코드 등 생산량을 줄일 수 있음

    public Text countText;



    public Image CursorGaugeImage;
    public GameObject mainCam;
    //public GameObject meText1;

    //public static bool AG_follow = false;

    [Header("PositionAndTime")]
    public Vector3 playerPosition;
    private float speed = 7.0f;
    public float GaugeTimer = 0.0f;
    public int ans = 0;
    public static float time = 0.0f;

    [Header("Talk")]
    public GameObject dialogueBox; //캐릭터들이 말하는
    public Text dialogueText;
    public GameObject playerBox; //플레이어가 말하는
    public Text playerText;
    public AudioSource audioSource;
    public AudioClip blop; //텍스트 박스 등장 소리
    public AudioClip ok;

    public Soccer soBool;

    public Animator ani;

    //[Header("Script")]
    //public follow fl;

    //public Animator ani;

    void Pop(GameObject Image) //텍스트박스 등장
    {
        Image.SetActive(true);
        audioSource.PlayOneShot(blop);
    }

    void Del(GameObject TB, GameObject Image) //텍스트박스 퇴장
    {
        TB.SetActive(false);
        Image.SetActive(false);
        //anything[0].SetActive(false);
    }

    public void StartTalking(string dialogue, float duration, GameObject tB, Text tT) //텍스트 진행 함수
    {
        tB.SetActive(true);
        tT.text = "";
        tT.DOText(dialogue, duration);
    }

    private bool a = false;
    private bool b = false;
    private bool c = false;
    private bool d = false;
    private bool e = false;
    private bool a1 = false;
    private bool b1 = false;
    private int count = 2;
    
    void Start()
    {
        //StartCoroutine(StartDialogue());//코루틴 시작
        //playerBox.GetComponent<Image>().enabled = false;
        //dialogueBox.GetComponent<Image>().enabled = false;
        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(this.transform.position, forward * 80, Color.green);
        CursorGaugeImage.fillAmount = GaugeTimer;

        countText.text = soBool.count.ToString();
       
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.transform.tag.Equals("target1") && !a)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    StartCoroutine(Dialogue1());
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("target2") && !b)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    StartCoroutine(Dialogue2());
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("camera") && count!=0 &&!d)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    //Del(playerBox, CC);
                    StartCoroutine(Dialogue3());
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("Coin") && !e)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    GameObject.Find("soccer_spawn").GetComponent<Soccer>().soccer_s();
                    
                    GaugeTimer = 0.0f;
                }
            }

            else
            {
                GaugeTimer = 0.0f;
            }
        }
        else
        {
            GaugeTimer = 0.0f;
        }

        if (a1 && b1)
        {
            c = true;
        }
    }



    public IEnumerator StartDialogue()
    {
        gameObject.GetComponent<PlayerCtrl2>().enabled = false;
        //시작할 때 fadein이 실행
        yield return new WaitForSeconds(4.0f);
        ani.SetBool("out", false);

        yield return new WaitForSeconds(1.0f);
        Pop(player);
        StartTalking("여기가 아리가 어제 놀았다는 놀이터구나.", 3.0f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("아리가 놀이터 모래사장 위에 사진을 놓고 왔다고 했으니까 \n모래사장으로 가서 확인해보자.", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player); //텍스트박스 퇴장

        yield return new WaitForSeconds(0.5f);
        Pop(AR);
        Pop(ARC);
        StartTalking("잠깐! 증거를 쉽게 줄 순 없지.", 2.0f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox, AR);

        Pop(AR);
        StartTalking("이 놀이터 안에 있는 동전을 5개 맞추면 \n그때 증거물의 위치를 알려줄게.", 5.0f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AR);

        Pop(AR);
        StartTalking("자, 시작해봐!", 2.0f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox, AR);

        Del(dialogueBox, img);
        Del(dialogueBox, ARC);

        gameObject.GetComponent<PlayerCtrl2>().enabled = true;

        Pop(coin); //코인생성
        Pop(BB); //조준점 생성

        yield return new WaitUntil(() => Soccer.T);

        audioSource.PlayOneShot(ok);
        Del(dialogueBox, coin);
        Del(dialogueBox, BB);

        Pop(AR);
        StartTalking("코인5개를 다 모았네! \n내 미션을 완료했으니 증거물의 위치를 알려줄게.", 5.0f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AR);

        Pop(img);
        yield return new WaitForSeconds(1.0f);
        Pop(P);  //모래사장 위치 화살표

        Pop(TT1);
        Pop(TT2);

        Pop(AR);
        StartTalking("노란색 화살표 보이지? 그쪽으로 가면 찾을 수 있어.", 3.0f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox, AR);

        Pop(AR);
        StartTalking("그럼 꼭 범인을 찾길 바랄게~!", 2.0f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox, AR);

        Pop(AC1);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox,AC1);


        //나레이션 코드 StartTalking함수에 박스 종류, 텍스트 종류만 나레이션으로 바꿔줌.
        /*Pop(player);
        StartTalking("여기는 나레이션입니다.", 3f,dialogueBox, dialogueText);
        yield return new WaitForSeconds(4.0f);
        Del(dialogueBox, dialogueText);*/

        yield return new WaitUntil(() => c);

        yield return new WaitForSeconds(5.0f);

        Pop(player);
        StartTalking("놀이터에서 찾아볼 증거는 다 찾아본 것 같네.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("근데 호빵이가 왜 거짓말을 했을까... \n설마 호빵이가..??", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("남은 한 장소로 이동해서 \n증거물을 더 찾아보자.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("벚꽃나무 동네로 이동!!", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first_2");

        //a = false;

        //yield return new WaitForSeconds(4.0f);
        //SceneManager.LoadScene("first");

        //SceneManager.LoadSceneAsync("first");
    }

    public IEnumerator Dialogue1()
    {
        a = true;
        Del(playerBox, P);
        Pop(T1);

        Pop(player);
        StartTalking("어! 이건 아리와 땅오가 같이 찍은 사진이잖아?!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("어제 땅오가 아리를 만났다는 곳이 여기 놀이터였나보다!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("음..그러면 어제 땅오와 아리는 같이 있었다는 걸 알 수 있네.", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(CC);

        Pop(player);
        StartTalking("수사일지에 증거사진으로 남겨놓자. \n카메라를 바라봐!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        //yield return new WaitForSeconds(6.0f);
        //Del(playerBox, CC);



        //Del(playerBox, T1);
        yield return new WaitForSeconds(15.0f);
        a1 = true;
    }

    public IEnumerator Dialogue2()
    {
        b = true;
        Del(playerBox, P);
        Pop(T2);

        Pop(player);
        StartTalking("이건 무슨사진이지?", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("날씨가 좋아서 아리가 찍은 하늘사진인가보네.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        yield return new WaitForSeconds(1.0f);
        Pop(player);
        StartTalking("응?근데 오른쪽에 찍힌건 누구지??", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("호빵이...? \n호빵이는 어제 하루종일 집에있다고 하지않았나...?", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        Pop(CC);

        Pop(player);
        StartTalking("수사일지에 증거사진으로 남겨놓자. \n카메라를 바라봐!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        //yield return new WaitForSeconds(6.0f);
        //Del(playerBox, CC);
        yield return new WaitForSeconds(15.0f);
        b1 = true;
    }

    public IEnumerator Dialogue3()
    {
        Del(playerBox, CC);
        d = true;
        Pop(CA);
        Pop(C_2);
        yield return new WaitForSeconds(1.0f);
        Del(playerBox, C_2);
        Pop(C_1);
        yield return new WaitForSeconds(1.0f);
        Del(playerBox, C_1);
        Del(playerBox, img);


        SCreenShot.TakeScreenshot_Static(300, 300);
        Del(playerBox, CA);
        yield return new WaitForSeconds(1.0f);
        Pop(img);
        
        count--;

        if (a == true)
        {
            yield return new WaitForSeconds(3.0f);
            Del(playerBox, T1);
        }

        else if (b == true)
        {
            yield return new WaitForSeconds(3.0f);
            Del(playerBox, T2);
        }

        d = false;
    }

  


}

