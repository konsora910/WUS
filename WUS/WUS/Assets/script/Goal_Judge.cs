using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


/*=============================================
    ゴール判定スクリプト（簡易）
=============================================*/
public class Goal_Judge : MonoBehaviour
{
    // オブジェクトタグが「　Player　」なら処理続行
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.gameObject.tag == "Player")
        {
            // デバッグログに表示される
            Destroy(col.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
    


