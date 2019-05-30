using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pause : MonoBehaviour
{
    public Image image;
    public Sprite Sprite1;
    public Sprite Sprite2;
    int PauseNum;
    GameObject GameContro;
    GameController script;
    GameObject ResetButton;

    // Start is called before the first frame update
    void Start()
    {
        GameContro = GameObject.Find("GameController");
        script = GameContro.GetComponent<GameController>();
        ResetButton= GameObject.Find("Button"); 
    }


    // Update is called once per frame
    void Update()
    {
        switch (PauseNum)
        {
            case 0:
                image.sprite = Sprite1;
                break;
            case 1:
                image.sprite = Sprite2;
                break;
            default:
                break;
        }
    }

    public void PauseNumSet()
    {
        if(PauseNum==0)
        {
            PauseNum = 1;
            script.Quit();
            ResetButton.SetActive(false);
        }
        else
        {
            PauseNum = 0;
            script.notQuit();
            ResetButton.SetActive(true);
        }
    }
}
