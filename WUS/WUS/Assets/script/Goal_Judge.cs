using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


/*=============================================
    ゴール判定スクリプト（簡易）
=============================================*/
public class Goal_Judge : MonoBehaviour
{
    public AudioClip GoalSE;
    // オブジェクトタグが「　Player　」なら処理続行
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.gameObject.tag == "Player")
        {
            //GetComponent<AudioSource>().Play();
            // デバッグログに表示される
            Destroy(col.gameObject);
            StartCoroutine("CallGoal");
        }
    }
    private IEnumerator CallGoal()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(GoalSE);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameClearTest");
    }
}
    


