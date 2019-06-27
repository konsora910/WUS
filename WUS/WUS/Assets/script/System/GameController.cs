﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject option;
    public GameObject Sceneobject;

    public AudioClip SelectSE;
    GameObject Fade;
    GameObject ssui;
    StageSelectUIControll SSUC;
    int FadeTimeMax = 60;
    int FadeTime = 0;
    bool TitleFadeCheck = false;
    bool MenuFadeCheck = false;
    private bool TutorialFadeCheck = false;
    bool FinishFadeCheck = false;

    GameObject PauseButton;
    // UI_Pause PauseScript;
    GameObject ResetButton;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("Fade");
        Fade.GetComponent<Fade>().FadeIn();
        PauseButton = GameObject.Find("Button (1)");
        ResetButton = GameObject.Find("Button");
    }
    public void Quit()
    {
        option.gameObject.SetActive(true);
        Sceneobject.gameObject.SetActive(false);

    }
    public void notQuit()
    {
        option.gameObject.SetActive(false);
        Sceneobject.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (TitleFadeCheck == true)
        {
            TitleFadeOut();
        }

        if (MenuFadeCheck == true)
        {
            StartCoroutine("MenuFadeOut");
        }

        if (FinishFadeCheck == true)
        {
            FinishFadeOut();
        }

    }

    public void TitleScene()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        TitleFadeCheck = true;


    }

    void TitleFadeOut()
    {
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            TitleFadeCheck = false;
            SceneManager.LoadScene("TitleScene");
        }
    }

    public IEnumerator MenuFadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            MenuFadeCheck = false;
            SceneManager.LoadScene("MenuScene");
        }
    }
    public void MenuScene()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        MenuFadeCheck = true;
    }
    public void GameFinish()
    {
        FinishFadeCheck = true;
    }

    void FinishFadeOut()
    {
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            FinishFadeCheck = false;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
            Application.OpenURL("http://www.yahoo.co.jp/");
#else
            Application.Quit();
#endif
        }

    }
    public void Cancel()
    {
        option.gameObject.SetActive(false);
        Sceneobject.gameObject.SetActive(true);
    }
    public void tutorial()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        DontDestroyOnLoad(SelectSE);
        SceneManager.LoadScene("SampleScene");
    }

    void TutorialFadeOut()
    {
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            TutorialFadeCheck = false;
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void CallSlide()
    {
        ssui = GameObject.Find("StageSelectUI");
        SSUC = ssui.GetComponent<StageSelectUIControll>();
        SSUC.test(true);
    }
}