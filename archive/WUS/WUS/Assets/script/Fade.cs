using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public float fSpeed = 0.01f;     //フェードの速さ
    float fAlfa = 1.0f;              //α値を操作するための変数
    float fRed, fGreen, fBlue;       //RGB値
    
    //初期処理
    void Start()
    {
        //FadePanelの色を取得
        fRed = GetComponent<Image>().color.r;
        fGreen = GetComponent<Image>().color.g;
        fBlue = GetComponent<Image>().color.b;
    }

    // 更新処理
    void Update()
    {
        GetComponent<Image>().color = new Color(fRed, fGreen, fBlue, fAlfa);
            fAlfa -= fSpeed;
    }
    
}
