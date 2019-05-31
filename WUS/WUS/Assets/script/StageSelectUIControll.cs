using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUIControll : MonoBehaviour
{
    public GameObject Tutrial;
    bool change = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{

        //    Tutrial.SetActive(false);

        //}

        //if (Input.GetKey(KeyCode.Space))
        //{

        //    Tutrial.SetActive(true);
        //}
    }
    
    public void test(bool c)
    {
        change = c;
        if (change)
        {
            this.gameObject.SetActive(false);
            Tutrial.SetActive(true);
            change = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            Tutrial.SetActive(false);
            change = true;
        }
    }
}
