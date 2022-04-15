using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject Me;//움직이고자 하는 물체
    private Transform Cam;//vr카메라
    private CharacterController cc; //component CharacterController를 받아야해요
    private float speed; // 움직이고자 하는 속도

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main.GetComponent<Transform>();//카메라 위치값 받아옴
        cc = Me.GetComponent<CharacterController>(); // 움직이고자 하는 물체에 캐릭터 컨트롤러를 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        if (Cam.eulerAngles.x >= 25.0f && Cam.transform.eulerAngles.x < 300)
        {
            speed = 20.0f;//카메라의 기울기 조정 해당 만큼 고개를 숙이면 이동
        }
        else
        {
            speed = 0f;
        }
        cc.SimpleMove(Cam.forward * speed); // 앞으로 가게하는 코드
    }
}
