using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    float fadeSpeed = 0.05f;
    float red, green, blue, alfa;

    public bool isFadeOut = false;
    public bool isFadeIn = false;

    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        isFadeIn = true;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;
        SetAlpha();
        if (alfa <= 0)
        {
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    public void FadeOut()
    {
        isFadeOut = true;
    }
    public void FadeIn()
    {
        isFadeIn = true;
    }
}