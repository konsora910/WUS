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
    bool FinishFadeCheck = false;
    bool Stage1FadeCheck = false;
    bool Stage2FadeCheck = false;
    bool Stage3FadeCheck = false;
    bool Stage4FadeCheck = false;
    static bool TimeOverFadeCheck = false;


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
        if(Stage1FadeCheck == true)
        {
            StartCoroutine("Stage1FadeOut");
        }
        if (Stage2FadeCheck == true)
        {
            StartCoroutine("Stage2FadeOut");
        }
        if (Stage3FadeCheck == true)
        {
            StartCoroutine("Stage3FadeOut");
        }
        if (Stage4FadeCheck == true)
        {
            StartCoroutine("Stage4FadeOut");
        }

        if (TimeOverFadeCheck == true)
        {
            StartCoroutine("TimeOverFadeOut");
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
    public void Stage1()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        Stage1FadeCheck = true;
    }
    public void Stage2()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        Stage2FadeCheck = true;
    }
    public void Stage3()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        Stage3FadeCheck = true;
    }
    public void Stage4()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(SelectSE);
        Stage4FadeCheck = true;
    }
    public static void TimeOver()
    {
         TimeOverFadeCheck = true;
    }

    //  public void TutorialFadeOut()
    //  {
    //      Fade.GetComponent<Fade>().FadeOut();
    //      FadeTime++;
    //      if (FadeTime > FadeTimeMax)
    //      {
    //          FadeTime = 0;
    //          TutorialFadeCheck = false;
    //          SceneManager.LoadScene("SampleScene");
    //      }
    //  }
    public IEnumerator Stage1FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            MenuFadeCheck = false;
            StageCheck.NowStage1();
            SceneManager.LoadScene("SampleScene");
        }
    }
    public IEnumerator Stage2FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            MenuFadeCheck = false;
            StageCheck.NowStage2();
            SceneManager.LoadScene("StageScene");
        }
    }
    public IEnumerator Stage3FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            MenuFadeCheck = false;
            StageCheck.NowStage3();
            SceneManager.LoadScene("stage5");
        }
    }
    public IEnumerator Stage4FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            MenuFadeCheck = false;
            StageCheck.NowStage4();
            SceneManager.LoadScene("SampleScene 1");
        }
    }
    public IEnumerator TimeOverFadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        Fade.GetComponent<Fade>().FadeOut();
        FadeTime++;
        if (FadeTime > FadeTimeMax)
        {
            FadeTime = 0;
            TimeOverFadeCheck = false;
            SceneManager.LoadScene("TimeOver");
        }
    }
    public void CallSlide()
    {
        ssui = GameObject.Find("StageSelectUI");
        SSUC = ssui.GetComponent<StageSelectUIControll>();
        SSUC.test(true);
    }


    public void Restart()
    {
        if(StageCheck.NowStage == 1)
        {
            Stage1();
        }
        if (StageCheck.NowStage == 2)
        {
            Stage2();
        }
        if (StageCheck.NowStage == 3)
        {
            Stage3();
        }
        if (StageCheck.NowStage == 4)
        {
            Stage4();
        }
    }

    public void ClearRestart()
    {
        if(StageCheck.StageClearCheck ==1)
        {
            Stage2();
        }
        if (StageCheck.StageClearCheck == 2)
        {
            Stage3();
        }
        if (StageCheck.StageClearCheck == 3)
        {
            Stage4();
        }
        if (StageCheck.StageClearCheck == 4)
        {
            MenuScene();
        }
    }


}
