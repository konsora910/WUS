using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUIControll : MonoBehaviour
{
    public GameObject Tutrial;
    bool change = false;

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
