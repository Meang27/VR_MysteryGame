using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soccer : MonoBehaviour
{
    public GameObject soccer_prefab;
    private GameObject instance;
    public int count = 0;

    //public Talking3 talk;

    public static bool T = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.GetComponent<SoccerCtrl>().count == 1)
        {
            count++;
            instance.GetComponent<SoccerCtrl>().count = 0;
            if(count == 5)
            {
                T = true;
            }
        }
    }

    public void soccer_s()
    {
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        instance = Instantiate(soccer_prefab, transform.position, transform.rotation) as GameObject;
        instance.gameObject.GetComponent<SoccerCtrl>().Shoot(forward*30000);
        Destroy(instance,1.0f);
    }
}
