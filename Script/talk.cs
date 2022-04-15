using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    public Text me;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialogue());
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(3.0f);
        me.text = "";
        me.DOText("아지,아리,땅오,호빵이랑 만나기로 한 시간이 다 되었네! \n이제 약속 장소로 슬슬 가봐야겠다.", 6.0f);
        yield return new WaitForSeconds(6.0f);
        me.text = "";
    }
}
