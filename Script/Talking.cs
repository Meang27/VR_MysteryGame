using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Talking : MonoBehaviour
{
    [Header("Player")]
    public GameObject player; //텍스트 박스 이미지
    public GameObject AG; //아지 텍스트 박스
    public GameObject Ch; //선택창
    public GameObject H; //헬기 선택창
    public GameObject AC1; //설명창
    public GameObject AC2; //설명창2
    public GameObject Tree1;
    public GameObject Tree2;
    public GameObject HEL; //헬기

    


    public Image CursorGaugeImage;
    public GameObject mainCam;
    //public GameObject meText1;

    public static bool AG_follow = false;

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

    [Header("Script")]
    public follow fl;

    public Animator ani;
    public Animator ani2;

    void Pop(GameObject Image) //텍스트박스 등장
    {
        Image.SetActive(true);
        audioSource.PlayOneShot(blop);
    }

    void Del(GameObject TB,GameObject Image) //텍스트박스 퇴장
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
    private bool a1 = false;
    private bool b = false;
    private bool c = false;
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


        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.transform.tag.Equals("dog") && !a &&!a1)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    a = true;
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("yes1") && !b)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    b = true;
                    GaugeTimer = 0.0f;
                }
            }
        
            else if (hit.transform.tag.Equals("yes2") && !c)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    c = true;
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



    public IEnumerator StartDialogue()
    {
        gameObject.GetComponent<PlayerCtrl>().enabled = false;
        //시작할 때 fadein이 실행
        yield return new WaitForSeconds(4.0f);
        ani.SetBool("out", false);
        a1 = true;

        Pop(player);
        //yield return new WaitForSeconds(1.0f);
        StartTalking("아지,아리,땅오,호빵이랑 만나기로 한 시간이 다 되었네! \n이제 약속 장소로 슬슬 가봐야겠다.", 6.0f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        Pop(AC1);
        a1 = false;
        gameObject.GetComponent<PlayerCtrl>().enabled = true;
        //아지를 처음봤을 때
        yield return new WaitUntil(() => a);
        audioSource.PlayOneShot(ok);

        Pop(player);
        StartTalking("어! 저기 아지가 있네? \n같이 만나서 가면 되겠다.", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox,player); //텍스트박스 퇴장
        Del(player, AC1);

        Pop(player);
        StartTalking("아지에게 가보자!", 2f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox,player);



        //나레이션 코드 StartTalking함수에 박스 종류, 텍스트 종류만 나레이션으로 바꿔줌.
        /*Pop(player);
        StartTalking("여기는 나레이션입니다.", 3f,dialogueBox, dialogueText);
        yield return new WaitForSeconds(4.0f);
        Del(dialogueBox, dialogueText);*/

        //아지 근처에 갔을 때
        yield return new WaitUntil(() => dog_talk.On);
        audioSource.PlayOneShot(ok);
        Pop(player);
        
        StartTalking("아지야 무슨일이야? 왜 혼자 울고있어?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox,player);

        Pop(AG);
        StartTalking("내가 제일 좋아하는 게임기를 잃어버렸어.\n분명 이 나무아래에 나뒀는데 누가 가져갔나봐.", 7f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(7.0f);
        Del(dialogueBox,AG);

        Pop(player);
        StartTalking("이런...속상하겠다. \n내가 도와줄까??", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(AG);
        StartTalking("정말?? 그래주면 나는 너무 고맙지. \n내 게임기 찾는걸 도와줄래?", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        yield return new WaitForSeconds(1.0f);
        Pop(player);
        StartTalking("아지의 게임기를 찾는걸 도와줄까?", 4f, playerBox, playerText);
        //yield return new WaitForSeconds(4.0f);
        //Del(playerBox, player);

        yield return new WaitForSeconds(4.0f);
        Pop(Ch);

        //a = false;

        //yes를 바라봤을 때
        yield return new WaitUntil(() => b);

        audioSource.PlayOneShot(ok);
        ani2.SetBool("happy", true);

        Del(playerBox, player);
        Del(player,Ch);


        yield return new WaitForSeconds(1.0f);
        Pop(AG);
        StartTalking("찾는걸 도와준다고? 고마워!! \n찾으면 이 은혜 잊지않을게.", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        

        Pop(player);
        StartTalking("마침 오늘 다같이 만나기로 한 약속이 있으니까 \n약속장소로 가면 다들 모여있을거야.", 7f, playerBox, playerText);
        yield return new WaitForSeconds(7.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("약속장소로 가보자!", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Del(playerBox, Tree1);
        Del(playerBox, Tree2);
        Pop(HEL);

        Pop(AC2);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, AC2);

        //아지와 함께 헬기에 탑승하세요

        yield return new WaitUntil(() => a); //아지가 따라오는
        fl.enabled = true;

        yield return new WaitForSeconds(3.0f);
        Pop(H);
        //'네'를 바라봤을때
        yield return new WaitUntil(() => c);
        audioSource.PlayOneShot(ok);
        //c = false;

        Del(playerBox,H);
        Pop(player);
        StartTalking("약속장소로 출발!", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first");

        //SceneManager.LoadSceneAsync("first");
    }


}

