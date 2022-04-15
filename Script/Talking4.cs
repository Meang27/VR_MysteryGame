using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Talking4 : MonoBehaviour
{
    [Header("Player")]
    public GameObject player; //텍스트 박스 이미지
    public GameObject AG; //아지 텍스트 박스
    public GameObject Ch; //선택창
    public GameObject Ch2;
    public GameObject AC1; //설명창

    public GameObject AG_0; //아지 나타나는
    public GameObject Fru; //과일박스
    public GameObject Fru2;
    public GameObject Fod; //음식박스
    public GameObject Fod2;
    public GameObject N1;
    public GameObject N2;
    public GameObject N3;
    public GameObject Fot; //발자국

    public Animator ani;

    public Image CursorGaugeImage;
    public GameObject mainCam;

   

    [Header("PositionAndTime")]
    public Vector3 playerPosition;
    private float speed = 20.0f;
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
    public AudioClip no;

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
    private bool c1 = false;

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

            if (hit.transform.tag.Equals("HH") && !b)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    StartCoroutine(Dialogue1());
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("JJ") && !c)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    StartCoroutine(Dialogue2());
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("HH2") && !d)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    StartCoroutine(Dialogue3());
                    GaugeTimer = 0.0f;
                }
            }

            else if (hit.transform.tag.Equals("JJ2") && !e)
            {
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




    public IEnumerator StartDialogue()
    {
        gameObject.GetComponent<PlayerCtrl>().enabled = false;
        yield return new WaitForSeconds(4.0f);
        ani.SetBool("out", false);

        yield return new WaitForSeconds(1.0f);
        Pop(player);
        StartTalking("여긴 어제 아지가 게임기를 잃어버렸다고 한 곳이네.", 4.0f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        //yield return new WaitUntil(() => a);

        Pop(player);
        StartTalking("한 번 주변을 둘러볼까?", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);




        yield return new WaitForSeconds(1.0f);
        Pop(AG_0);

        Pop(AG);
        StartTalking("잠깐! 내가 내는 퀴즈의 정답을 맞춰야지만 \n증거물을 찾을 수 있어.", 5f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AG);

        Pop(Fru);
        gameObject.GetComponent<PlayerCtrl>().enabled = true;

        Pop(AG);
        StartTalking("자, 이건 여러과일이 담겨져 있는 상자야.\n각 과일들이 몇 개인지 잘 기억해야해.", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        Pop(AG);
        StartTalking("기억할 수 있는 시간 3초 줄게. \n지금부터 시작!!", 4f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(4.0f);
        Del(dialogueBox, AG);

        Pop(N3);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, N3);
        Pop(N2);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, N2);
        Pop(N1);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, N1);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, Fru);


        Pop(AG);
        StartTalking("어때? 기억했어? 이제 내가 과일을 \n몇 개 가져가고 남은 상자를 보여줄거야.", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        Pop(AG);
        StartTalking("내가 몇 개 가져갔을지 생각한 후에 \n그 개수가 홀수인지 짝수인지 알아맞추면 돼.", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        yield return new WaitForSeconds(1.0f);
        Pop(Fru2);

        Pop(Ch);

        yield return new WaitUntil(() => c1);
        Pop(Fod);

        Pop(AG);
        StartTalking("이번에는 과일상자가 아닌 여러 음식이 담긴 상자야. \n이번에는 꼭 맞춰!!", 6f, dialogueBox, dialogueText); //4개 짝수
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        Pop(N3);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, N3);
        Pop(N2);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, N2);
        Pop(N1);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, N1);
        yield return new WaitForSeconds(1.0f);
        Del(dialogueBox, Fod);

        Pop(AG);
        StartTalking("내가 몇 개를 가져갔을까??", 3f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox, AG);

        Pop(Fod2);
        Pop(Ch2);


        yield return new WaitUntil(() => Foot.fot);

        Pop(player);
        StartTalking("어? 이게뭐지?? 발자국같은데....", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("땅오가 봤다고 했으니까 땅오의 발자국인건가?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("정말 땅오는 아지의 게임기를 보기만 한 것일까...\n땅오가 설마..?", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("에이..아닐거야..", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        yield return new WaitForSeconds(2.0f);
        Pop(player);
        StartTalking("이제 어느정도의 증거자료 수집은 끝난것 같아!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("다시 친구들이 모여있는 곳으로 가서 \n수집한 증거자료를 보여주며 범인을 추리해보자.", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        ani.SetBool("out", true);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("first_3");
    }
    //나레이션 코드 StartTalking함수에 박스 종류, 텍스트 종류만 나레이션으로 바꿔줌.
    /*Pop(player);
    StartTalking("여기는 나레이션입니다.", 3f,dialogueBox, dialogueText);
    yield return new WaitForSeconds(4.0f);
    Del(dialogueBox, dialogueText);*/

    public IEnumerator Dialogue1()
    {
        b = true;

        Del(dialogueBox, Fru2);
        Del(dialogueBox, Ch);

        audioSource.PlayOneShot(ok);
        Pop(AG);
        StartTalking("딩동댕! 정답이야!! 내가 5개의 과일을 가져갔지ㅎㅎ", 5f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AG);


        Pop(AG);
        StartTalking("기억력이 정말 좋은걸? 정답을 맞췄기 때문에 \n증거물의 위치를 알려줄게.", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        Pop(AG);
        StartTalking("벚꽃나무 아래를 자세히 봐바!", 3f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox, AG);

        Del(dialogueBox, AG_0);
        Pop(Fot);

        Pop(AC1);  //설명창
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, AC1);

        yield return new WaitUntil(() => Foot.fot);

        Pop(player);
        StartTalking("어? 이게뭐지?? 발자국같은데....", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("땅오가 봤다고 했으니까 땅오의 발자국인건가?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("정말 땅오는 아지의 게임기를 보기만 한 것일까...\n땅오가 설마..?", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("에이..아닐거야..", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        yield return new WaitForSeconds(2.0f);
        Pop(player);
        StartTalking("이제 어느정도의 증거자료 수집은 끝난것 같아!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("다시 친구들이 모여있는 곳으로 가서 \n수집한 증거자료를 보여주며 범인을 추리해보자.", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first_3");
    }

    public IEnumerator Dialogue2()
    {
        c = true;

        Del(dialogueBox, Fru2);
        Del(dialogueBox, Ch);

        audioSource.PlayOneShot(no);
        Pop(AG);
        StartTalking("땡! 틀렸어...내가 가져간 과일은 \n총 5개로 홀수야.", 5f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AG);


        Pop(AG);
        StartTalking("한 번 더 기회를 줄게. \n다시 3초의 시간을 주지.", 5f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AG);

        c1 = true;
    }

    public IEnumerator Dialogue3()
    {
        d = true;

        Del(dialogueBox, Fod2);
        Del(dialogueBox, Ch2);

        audioSource.PlayOneShot(no);
        Pop(AG);
        StartTalking("땡!! 정답은 짝수였어...내가 4개를 가져갔거든", 5f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AG);


        Pop(AG);
        StartTalking("퀴즈를 틀려서 원래는 알려주면 안되는데 \n내 장난감을 찾아준다 했으니까 친히 알려주지.", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        Pop(AG);
        StartTalking("벚꽃나무 아래를 한 번 봐볼래?", 3f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox, AG);

        Del(dialogueBox, AG_0);
        Pop(Fot);

        Pop(AC1);  //설명창
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, AC1);

        yield return new WaitUntil(() => Foot.fot);

        Pop(player);
        StartTalking("어? 이게뭐지?? 발자국같은데....", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("땅오가 봤다고 했으니까 땅오의 발자국인건가?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("정말 땅오는 아지의 게임기를 보기만 한 것일까...\n땅오가 설마..?", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("에이..아닐거야..", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        yield return new WaitForSeconds(2.0f);
        Pop(player);
        StartTalking("이제 어느정도의 증거자료 수집은 끝난것 같아!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("다시 친구들이 모여있는 곳으로 가서 \n수집한 증거자료를 보여주며 범인을 추리해보자.", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first_3");
    }

    public IEnumerator Dialogue4()
    {
        d = true;

        Del(dialogueBox, Fod2);
        Del(dialogueBox, Ch2);

        audioSource.PlayOneShot(ok);
        Pop(AG);
        StartTalking("딩동댕! 정답이야. 내가 4개의 음식을 가져갔지.", 5f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(5.0f);
        Del(dialogueBox, AG);


        Pop(AG);
        StartTalking("다행이 두번째 기회에서는 정답을 맞췄네. \n증거물 위치 힌트를 줄게!", 6f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(6.0f);
        Del(dialogueBox, AG);

        Pop(AG);
        StartTalking("벚꽃나무 아래를 한 번 봐볼래?", 3f, dialogueBox, dialogueText);
        yield return new WaitForSeconds(3.0f);
        Del(dialogueBox, AG);

        Del(dialogueBox, AG_0);
        Pop(Fot);

        Pop(AC1);  //설명창
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, AC1);

        yield return new WaitUntil(() => Foot.fot);

        Pop(player);
        StartTalking("어? 이게뭐지?? 발자국같은데....", 3f, playerBox, playerText);
        yield return new WaitForSeconds(3.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("땅오가 봤다고 했으니까 땅오의 발자국인건가?", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("정말 땅오는 아지의 게임기를 보기만 한 것일까...\n땅오가 설마..?", 5f, playerBox, playerText);
        yield return new WaitForSeconds(5.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("에이..아닐거야..", 2f, playerBox, playerText);
        yield return new WaitForSeconds(2.0f);
        Del(playerBox, player);

        yield return new WaitForSeconds(2.0f);
        Pop(player);
        StartTalking("이제 어느정도의 증거자료 수집은 끝난것 같아!", 4f, playerBox, playerText);
        yield return new WaitForSeconds(4.0f);
        Del(playerBox, player);

        Pop(player);
        StartTalking("다시 친구들이 모여있는 곳으로 가서 \n수집한 증거자료를 보여주며 범인을 추리해보자.", 6f, playerBox, playerText);
        yield return new WaitForSeconds(6.0f);
        Del(playerBox, player);

        ani.SetBool("out", true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("first_3");
    }

}


