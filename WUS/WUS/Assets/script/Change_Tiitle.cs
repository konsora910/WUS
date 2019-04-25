using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Change_Tiitle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject image_object;     //UIの取得
    public Image image_component;       //UIの色とか変えるやつ
    public Transform myTransform;      //UIの大きさとか位置とか変えるやつ

    // Start is called before the first frame update
    void Start()
    {
        image_object = GameObject.Find("Image");
        // コンポーネントの取得
        image_component = image_object.GetComponent<Image>();
        myTransform = image_object.GetComponent<Transform>();

        image_component.color = Color.blue; //赤色を代入
        myTransform.localPosition = new Vector3(-100.0f, 100.0f,0.0f); //位置変更
        myTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);        //サイズ変更
    }
    
    //　マウスがUIをクリックしたら
    public void OnPointerClick(PointerEventData pointerData)
    {
        SceneManager.LoadScene("SampleScene");
    }

    // マウスがUIと重なったら
       public void OnPointerEnter(PointerEventData eventData)
    {
        image_component.color = Color.red;
    }

    //　マウスがUIから離れたら
    public void OnPointerExit(PointerEventData eventData)
    {
        image_component.color = Color.blue;
    }
}

