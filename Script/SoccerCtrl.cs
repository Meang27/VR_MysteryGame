using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoccerCtrl : MonoBehaviour
{
    float timer = 0.0f;
    bool is_shoot = false;
    public int count = 0;

    public AudioClip adc;
    private AudioSource adis;
    public bool coin = false;
    
    //public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        adis = gameObject.GetComponent<AudioSource>();
        //countText.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!is_shoot)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            is_shoot = true;
        }
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Coin")
        {
            count = 1;
            adis.clip = adc;
            adis.Play();
            Destroy(other.gameObject);
            
        }
    }
}
