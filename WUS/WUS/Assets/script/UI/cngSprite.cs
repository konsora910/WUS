using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cngSprite : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;

    public GameObject stCont;
    StageSelectUIControll SSUC;
    
    private int flag = 0;

    private void Start()
    {
        SSUC = stCont.GetComponent<StageSelectUIControll>();
    }
    
    public void ChangeSprite()
    {
        switch (flag)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = sprite2;
                flag = 1;
                break;
            case 1:
                SSUC.test(false);
                this.gameObject.GetComponent<Image>().sprite = sprite1;
                flag = 0;
                break;
            default:
                break;
        }
    }
}
