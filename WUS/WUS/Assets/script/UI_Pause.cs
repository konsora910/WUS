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

    public bool bPause;

    // Start is called before the first frame update
    void Start()
    {
        GameContro = GameObject.Find("GameController");
        script = GameContro.GetComponent<GameController>();
        ResetButton = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {

        if (!bPause)
        {
            image.sprite = Sprite1;
        }
        else
        {
            image.sprite = Sprite2;
        }
    }
    public void PauseNumSet()
    {
        if (!bPause)
        {
            bPause = true;
            script.Quit();
            ResetButton.SetActive(false);
        }
        else
        {
            bPause = false;
            script.notQuit();
            ResetButton.SetActive(true);
        }
    }
}
