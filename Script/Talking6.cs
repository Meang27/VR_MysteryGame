using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Talking6 : MonoBehaviour
{
    [Header("Player")]
    public GameObject player; //텍스트 박스 이미지
    public GameObject AG; //아지 텍스트 박스
    public GameObject AR; //아리 텍스트 박스
    public GameObject HB; //호빵 텍스트 박스
    public GameObject DO; //땅오 텍스트 박스
    public GameObject PR; //포리 텍스트 박스
    public GameObject Ch; //선택창
    public GameObject Ch2; //수사할 선택창
    public GameObject Game;

    public GameObject PR_2;
    public GameObject AG_2;
    public GameObject AR_2;
    public GameObject HB_2;
    public GameObject HB_3;
    public GameObject DO_2;

    public GameObject End;


    public Image CursorGaugeImage;
    public GameObject mainCam;
    public GameObject meText1;

    [Header("PositionAndTime")]
    public Vector3 playerPosition;
    private float speed = 20.0f;
    public float GaugeTimer = 0.0f;
    public int ans = 0;
    public static float time = 0.0f;

    [Header("Talk")]
    public GameObject dialogueBox1; //아지
    public Text dialogueText1;
    public GameObject dialogueBox2; //아리
    public Text dialogueText2;
    public GameObject dialogueBox3; //호빵
    public Text dialogueText3;
    public GameObject dialogueBox4; //땅오
    public Text dialogueText4;
    public GameObject dialogueBox5; //포리
    public Text dialogueText5;
    public AudioSource audioSource;
    public AudioClip policecar;
    public AudioClip ok;
    public AudioClip no;

    public GameObject playerBox; //플레이어가 말하는
    public Text playerText;
    public AudioClip blop; //텍스트 박스 등장 소리

    public Animator ani;
    public Animator ani2;
    public Animator ani3;
    public Animator ani4;
    public Animator ani5;
    public Animator ani6;

    void Pop(GameObject Image) //텍스트박스 등장
    {
        Image.SetActive(true);
        audioSource.PlayOneShot(blop);
    }

    void Del(GameObject TB, GameObject Image) //텍스트박스 퇴장
    {
        TB.SetActive(false);
        Image.SetActive(false);
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
    [SerializeField]
    private bool f = false;
    private bool b1 = false;
    private bool c1 = false;
    private bool d1 = false;
    private bool e1 = false;
    private bool f1 = false;
    private bool animal = false;

    private bool AA = false;
    private bool RR = false;
    private bool HH = false;
    private bool DD = false;

    private bool p = false;
    private bool t = false;

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
        Debug.DrawRay(this.transform.position, forward * 200, Color.green);
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (animal == true)
        {
            if (Physics.Raycast(transform.position, forward, out hit))
            {
                if (hit.transform.tag.Equals("dog") && !b1)
                {
                    //Pop(AG_2);

                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue1());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("tiger") && !c1)
                {
                    //Pop(HB_2);

                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue2());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("yellow") && !d1)
                {
                    //Pop(AR_2);

                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue3());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("shark") && !e1)
                {
                    //Pop(DO_2);

                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue4());
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
        }

        if (b && c && d && e)
        {
            a = true;
        }

        if(f == true)
        {
            if (Physics.Raycast(transform.position, forward, out hit))
            {
                if (hit.transform.tag.Equals("AAA") && !AA)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue8());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("RRR") && !RR)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue8());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("HHH") && !HH)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        audioSource.PlayOneShot(ok);
                        StartCoroutine(Dialogue7());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("DDD") && !DD)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue8());
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
        }
    }




    public IEnumerator StartDialogue()
    {
        //시작할 때 fadein이 실행
        yield return new WaitForSeconds(4.0f);
        ani.SetBool("out", false);


        yield return new WaitForSeconds(1.0f);
        Pop(player);
        StartTalking("얘들아! 내가 증거물을 수집하고 왔어.", 4.0f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        //yield return new WaitUntil(() => a);
        //a = false;

        yield return new WaitForSeconds(1.0f);
        Pop(AR); //아리
        StartTalking("정말?? 내가 찍은 사진도 봤어??", 3f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox2, AR); //텍스트박스 퇴장

        Pop(player);
        StartTalking("응응! 다보고왔어. 그 이외에도 다른 증거물을 찾았어.", 5.0f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        yield return new WaitForSeconds(1.0f);
        Pop(DO); //땅오
        StartTalking("범인을 찾을 수 있을 것 같아?", 3f, dialogueBox4, dialogueText4);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox4, DO);

        Pop(player);
        StartTalking("음..헷갈리긴 하지만 내 예상이 맞다면 \n범인은....", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(Ch);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, Ch);

        animal = true;

        

        yield return new WaitUntil(() => a);
        a = false;

        b1 = true;
        c1 = true;
        d1 = true;
        e1 = true;

        audioSource.PlayOneShot(policecar);
        ani2.SetBool("Police", true);
        yield return new WaitForSeconds(7.0f);
        Pop(PR_2);

        yield return new WaitForSeconds(1.0f);
        Pop(PR); //포리
        StartTalking("게임기 도난 사건이 발생했다 하여 왔습니다.\n혹시 범인을 찾았나요??", 5f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox5, PR);

        Pop(PR); //포리
        StartTalking("저는 이번 사건의 범인을 알고있습니다. 알고 그 친구를 잡으러 온거고요. \n범인이 누구라고 생각하나요?", 6f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox5, PR);

        animal = false;
        f = true;
        Pop(Ch2);


    }

    public IEnumerator Dialogue1()
    {

        b1 = true;
        c1 = true;
        d1 = true;
        e1 = true;

        Pop(player);
        StartTalking("아지가 친구들의 사이를 고의로 나쁘게 만들기 위한 \n이건 아지의 자작극이야!", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("그러므로 이번 사건의 범인은 아지야!!", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(AG);
        StartTalking("나라고..? 내가 왜 굳이 자작극을 하면서까지 \n이런 난리를 피우겠어...나 아니야...ㅠㅠ", 6f, dialogueBox1, dialogueText1);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox1, AG);

        Pop(AG_2);

        c1 = false;
        d1 = false;
        e1 = false;

        b = true;
    }

    public IEnumerator Dialogue2()
    {

        c1 = true;
        b1 = true;
        d1 = true;
        e1 = true;

        Pop(player);
        StartTalking("놀이터에 갔었는데 하루종일 집에 있었다고 거짓말한 호빵이! \n거짓말을 한게 수상해.", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("아지의 게임기를 훔치고 놀이터에서 아지 게임기를 갖고 놀았지!? \n범인은 너 호빵이야!", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(HB);
        StartTalking("나라고...? 나는 거짓말을 한 적이 없어. 집에만 있던거 맞아!! \n나는 아니야!", 5f, dialogueBox3, dialogueText3);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox3, HB);

        Pop(HB_2);

        b1 = false;
        d1 = false;
        e1 = false;

        c = true;

    }

    public IEnumerator Dialogue3()
    {

        d1 = true;
        b1 = true;
        c1 = true;
        e1 = true;

        Pop(player);
        StartTalking("아리야 하루종일 놀이터에만 있던게 맞아?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(AR);
        StartTalking("응...놀이터에서 놀다가 집간게 다야...", 3f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox2, AR);

        Pop(player);
        StartTalking("하루종일 놀이터에서만 있었다는 증거가 없어! \n놀이터에서 놀고 아지 게임기를 탐냈을지도 모르는 일이야!", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("그니까 이번 사건의 범인은 아리야!!", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(AR);
        StartTalking("무슨말이야ㅠㅠ..난 아지 게임기를 가져가지도 않았고, \n본 적도 없어.. 난 정말아니야!! 억울해", 5f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox2, AR);

        Pop(AR_2);

        b1 = false;
        c1 = false;
        e1 = false;

        d = true;
    }

    public IEnumerator Dialogue4()
    {

        e1 = true;
        b1 = true;
        c1 = true;
        d1 = true;

        Pop(player);
        StartTalking("땅오야 그날 왜 아지가 게임기를 잃어버린 장소에 갔던거야?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(DO);
        StartTalking("어..아마 아지가 게임하는걸 옆에서 같이 지켜봤던 것 같아. \n그렇다고 내가 가져간건 정말 아니야!", 5f, dialogueBox4, dialogueText4);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox4, DO);

        Pop(player);
        StartTalking("아지의 게임기를 옆에서 지켜보다가 너도 하고싶은 마음에 \n순간 욕심이 생겼을 수도 있잖아?! 땅오, 너지?!", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        Pop(DO);
        StartTalking("난 아지 게임기에 손대지 않았어!!", 3f, dialogueBox4, dialogueText4);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox4, DO);

        Pop(DO_2);

        b1 = false;
        c1 = false;
        d1 = false;

        e = true;
    }

    public IEnumerator Dialogue5()
    {
        p = true;

        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first_1");
    }

    public IEnumerator Dialogue6()
    {
        t = true;
        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first_2");
    }

    public IEnumerator Dialogue7()
    {
        AA = true;
        RR = true;
        HH = true;
        DD = true;

        Del(dialogueBox5, Ch2);
        Del(dialogueBox5, AG_2);
        Del(dialogueBox5, AR_2);
        Del(dialogueBox5, HB_2);
        Del(dialogueBox5, DO_2);
        //정답을 고를시
        Pop(PR); //포리
        StartTalking("맞아요. 이번 사건의 범인은 호빵이입니다.\n호빵이 친구는 그날 집이 아닌 놀이터에 있었습니다.", 5f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox5, PR);

        Pop(PR); //포리
        StartTalking("아지가 잠깐 자리를 비운 사이 호빵이는 아지의 게임기를 가져갔고, \n놀이터에서 아지의 게임기를 가지고 놀았습니다.", 6f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox5, PR);

        Pop(PR); //포리
        StartTalking("호빵아 어서 아지에게 게임기를 돌려주렴.", 2f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox5, PR);

        Pop(Game);
        ani6.SetBool("give", true);
        ani3.SetBool("sad", true);
        //게임기를 주는 모션
        yield return new WaitForSeconds(2.0f);
        Pop(HB);
        StartTalking("미안해 아지야...가져갈 생각은 아니였는데 너가 자리를 비운사이에 \n잠깐 나쁜생각을 한 것 같아.", 5f, dialogueBox3, dialogueText3);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox3, HB);

        ani4.SetBool("game", true);
        yield return new WaitForSeconds(2.0f);
        Pop(AG);
        StartTalking("다시 되돌려줘서 고마워. 내 게임기가 하고싶으면 언제든 말해! \n내가 자주 빌려줄게 호빵아.", 5f, dialogueBox1, dialogueText1);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox1, AG);

        Pop(HB);
        StartTalking("아진짜?? 고마워 아지야..ㅠㅠ", 2f, dialogueBox3, dialogueText3);
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox3, HB);


        yield return new WaitForSeconds(2.0f);
        Pop(PR); //포리
        StartTalking("호빵이는 같이 경찰서로 가서 얘기를 더 나눠야합니다. \n여기 타렴 호빵아.", 4.0f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(4.0f);
        Del(dialogueBox5, PR);

        ani5.SetBool("walk", true);

        yield return new WaitForSeconds(15.0f);
        Del(dialogueBox5, HB_3);
        //경찰차가 떠나는 애니메이션
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox5, PR_2);
        audioSource.PlayOneShot(policecar);
        ani2.SetBool("Police", false);
        yield return new WaitForSeconds(2.0f);
        ani.SetBool("out", true);

        yield return new WaitForSeconds(8.0f);
        Pop(End);
        
        //사건2로 넘어가는
    }

    public IEnumerator Dialogue8()
    {
        AA = true;
        RR = true;
        HH = true;
        DD = true;
        //오답을 고를시

        audioSource.PlayOneShot(no);
        Pop(PR); //포리
        StartTalking("음...다시 생각해볼래요? 그친구는 범인이 아닙니다... \n다시 신중하게 생각해보고 알려주세요.", 5f, dialogueBox5, dialogueText5);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox5, PR);

        AA = false;
        RR = false;
        HH = false;
        DD = false;
    }



    //나레이션 코드 StartTalking함수에 박스 종류, 텍스트 종류만 나레이션으로 바꿔줌.
    /*Pop(player);
    StartTalking("여기는 나레이션입니다.", 3f,dialogueBox, dialogueText);
    yield return new WaitForSeconds(4.0f);
    Del(dialogueBox, dialogueText);*/
}

