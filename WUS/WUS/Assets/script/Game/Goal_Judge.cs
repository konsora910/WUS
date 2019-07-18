﻿using UnityEngine;
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
        if (StageCheck.NowStage == 1)
        {
            StageCheck.NowStage1();
        }
        if (StageCheck.NowStage == 2)
        {
            StageCheck.NowStage2();
        }
        if (StageCheck.NowStage == 3)
        {
            StageCheck.NowStage3();
        }
        if (StageCheck.NowStage == 4)
        {
            StageCheck.NowStage4();
        }

        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(GoalSE);
        GameObject.FindObjectOfType<AudioSource>().volume = 1.0f;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameClearTest");
    }
}
    


