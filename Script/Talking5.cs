using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Talking5 : MonoBehaviour
{
    [Header("Player")]
    public GameObject player; //텍스트 박스 이미지
    public GameObject AG; //아지 텍스트 박스
    public GameObject AR; //아리 텍스트 박스
    public GameObject HB; //호빵 텍스트 박스
    public GameObject DO; //땅오 텍스트 박스
    public GameObject Ch; //선택창
    public GameObject Ch2; //수사할 선택창


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

    public GameObject playerBox; //플레이어가 말하는
    public Text playerText;

    public Animator ani;

    void Pop(GameObject Image) //텍스트박스 등장
    {
        Image.SetActive(true);
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
    private bool b1 = false;
    private bool c1 = false;
    private bool d1 = false;
    private bool e1 = false;
    private bool animal = false;

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
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue1());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("tiger") && !c1)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue2());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("yellow") && !d1)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue3());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("shark") && !e1)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        StartCoroutine(Dialogue4());
                        GaugeTimer = 0.0f;
                    }
                }

                else if (hit.transform.tag.Equals("playground") && !p)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        SceneManager.LoadScene("first_1");
                    }
                }

                else if (hit.transform.tag.Equals("tree") && !t)
                {
                    GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        SceneManager.LoadScene("first_2");
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

    }




    public IEnumerator StartDialogue()
    {
        //시작할 때 fadein이 실행
        yield return new WaitForSeconds(4.0f);
        ani.SetBool("out", false);

        Pop(player);
        yield return new WaitForSeconds(2.0f);
        StartTalking("얘들아! 아지의 게임기 범인을 찾을 수 있을 것 같아!", 5.0f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        //yield return new WaitUntil(() => a);
        //a = false;
        Pop(AR); //아리
        yield return new WaitForSeconds(1.0f);
        StartTalking("진짜??내가 찍은 사진 찾았어??", 3f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox2, AR); //텍스트박스 퇴장

        Pop(player);
        yield return new WaitForSeconds(1.0f);
        StartTalking("응응!! 아리가 찍은 사진 2장을 발견했어.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(DO); //땅오
        yield return new WaitForSeconds(1.0f);
        StartTalking("아진짜? 사진말고 다른증거는?", 3f, dialogueBox4, dialogueText4);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox4, DO);

        Pop(player);
        yield return new WaitForSeconds(1.0f);
        StartTalking("음...범인현장에서 발자국도 나왔어.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        yield return new WaitForSeconds(1.0f);
        StartTalking("음...범인현장에서 발자국도 나왔어.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(Ch);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, Ch);

        animal = true;

        yield return new WaitUntil(() => a);

        //모든 친구들의 이야기를 다 들은 후

        yield return new WaitForSeconds(1.0f);

        Pop(player);
        StartTalking("어제 각자 뭐했는지 이야기를 다 들어봤어. \n정확한 증거가 나오기 전까지 범인을 찾기는 힘들것 같아.", 7f, playerBox, playerText);
        yield return new WaitForSeconds(7.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("심증은 있는데 물증이 없기 때문에 내가 한 번 증거를 찾고 \n 너희를 다시 찾아올게.", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("그럼 이따보자!", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        Pop(Ch2);
    }

    public IEnumerator Dialogue1()
    {

        b1 = true;

        Pop(player);
        StartTalking("아지야 어제 게임기를 어디에 뒀었어?", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(AG);
        yield return new WaitForSeconds(1.0f);
        StartTalking("어제 벚꽃나무 아래에서 게임을 하고 집을 왔는데 \n집에 도착하고 게임기를 두고 온게 생각났어.", 6f, dialogueBox1, dialogueText1);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox1, AG);

        Pop(AG);
        //yield return new WaitForSeconds(1.0f);
        StartTalking("그래서 다시 찾으러 갔는데 이미 게임기는 사라지고 없었어.", 4f, dialogueBox1, dialogueText1);
        yield return new WaitForSeconds(4.0f);
        Del(dialogueBox1, AG);

        b = true;
    }

    public IEnumerator Dialogue2()
    {

        c1 = true;

        Pop(player);
        StartTalking("호빵아 어제 뭐했어?", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(HB);
        yield return new WaitForSeconds(1.0f);
        StartTalking("나 어제 집에서 티비보고 있었지. \n하루종일 집에만 있었어.", 5f, dialogueBox3, dialogueText3);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox3, HB);

        yield return new WaitForSeconds(1.0f);
        Pop(player);
        StartTalking("그래? 아지 게임기는 본 적 없어?", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        Pop(HB);
        yield return new WaitForSeconds(1.0f);
        StartTalking("응 나는 본 적이 없어.", 2f, dialogueBox3, dialogueText3);
        yield return new WaitForSeconds(2.0f);
        Del(dialogueBox3, HB);

        c = true;

    }

    public IEnumerator Dialogue3()
    {

        d1 = true;

        Pop(player);
        StartTalking("아리야 어제 어디있었어?", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        Pop(AR);
        yield return new WaitForSeconds(1.0f);
        StartTalking("나 어제 친구들이랑 놀이터에서 놀았어.", 3f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox2, AR);

        Pop(player);
        StartTalking("그럼 누구누구랑 놀았어? ", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(AR);
        yield return new WaitForSeconds(1.0f);
        StartTalking("음..글쎄 사진찍고나서 노는데에 집중하느라 기억이 잘 안나.", 6f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox2, AR);

        //사진찍은거 볼 수 있어?

        Pop(AR);
        yield return new WaitForSeconds(1.0f);
        StartTalking("근데 그거 모래사장 위에 놓고온 것 같은데 아마 놀이터에 가면 찾을 수 있을거야.", 6f, dialogueBox2, dialogueText2);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox2, AR);

        d = true;
    }

    public IEnumerator Dialogue4()
    {

        e1 = true;

        Pop(player);
        StartTalking("땅오야 아지 게임기 본 적 있어?", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(DO);
        yield return new WaitForSeconds(1.0f);
        StartTalking("어! 혹시 벚꽃나무 아래에 있는 게임기 말하는거야?", 4f, dialogueBox4, dialogueText4);
        yield return new WaitForSeconds(4.0f);
        Del(dialogueBox4, DO);

        Pop(player);
        StartTalking("응 그거 맞아!!", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        Pop(DO);
        yield return new WaitForSeconds(1.0f);
        StartTalking("그거 어제 오후에 잠깐 아리 만나러 갔을 때 본 것 같아.", 5f, dialogueBox4, dialogueText4);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox4, DO);

        e = true;
    }



    //나레이션 코드 StartTalking함수에 박스 종류, 텍스트 종류만 나레이션으로 바꿔줌.
    /*Pop(player);
    StartTalking("여기는 나레이션입니다.", 3f,dialogueBox, dialogueText);
    yield return new WaitForSeconds(4.0f);
    Del(dialogueBox, dialogueText);*/
}

