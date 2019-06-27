using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


//=============================================
//    ゴール判定スクリプト（簡易）
//=============================================
public class Goal_Judge : MonoBehaviour
{
    public AudioClip GoalSE;
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            StartCoroutine("CallGoal");
        }
    }
    private IEnumerator CallGoal()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(GoalSE);
        GameObject.FindObjectOfType<AudioSource>().volume = 1.0f;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameClearTest");
    }
}
    


