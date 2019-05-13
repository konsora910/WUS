using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===========================================================================
 
     
     チェックポイント単体の操作スクリプト
     
     
     
     
===========================================================================*/

public class CheckPoint : MonoBehaviour
{
    enum Mode
    {
        collision,
        trigger
    };
    private readonly float tX = 0.5f;// カメラの移動速度
    public float stMove = 0.0f;// 移動量保管変数
    private readonly Mode mode;

    PlayerController PCont;
    private bool StopCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        if (mode == Mode.collision)
        {
            GetComponentInChildren<Collider2D>().isTrigger = false;
        } else if (mode == Mode.trigger)
        {
            GetComponentInChildren<Collider2D>().isTrigger = true;
        }
    }

    // 常にかかる更新処理
    private void FixedUpdate()
    {
        if (StopCamera)
        {
            Camera.main.gameObject.transform.Translate(tX, 0.0f, 0.0f);
            if (Camera.main.gameObject.transform.position.x >= stMove)
            {
                StopCamera = false;
                PCont.enabled = true;
                //GetComponent<SelectCPoint>().numCheck++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            JudgeCheck(collision.collider);
            StopCamera = true;
            Debug.Log("Collision : CheckPoint");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            JudgeCheck(collision);
        }
    }

    // キャラクター判定処理
    void JudgeCheck(Collider2D colCheck)
    {
        if(colCheck.gameObject.tag == "Player")
        {
            // キャラクターの動きを止める
            PCont = colCheck.GetComponent<PlayerController>();
            PCont.enabled = false;
        }
    }

    // 移動量のセット関数（譲渡先 : SelectCPoint.cs）
    public void stmoveSet(float move)
    {
        stMove = move;
    }
}
