using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    enum Mode
    {
        collision,
        trigger
    };
    public float Move1;
    public float Move2;
    private float stMove;
    private Mode mode;
    private bool isCheck;
    private int nCheck = 0;
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
        switch (nCheck)
        {
            case 0:
                stMove = Move1;
                break;
            case 1:
                stMove = Move2;
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (StopCamera)
        {
            Camera.main.gameObject.transform.position += new Vector3(0.5f, 0.0f, 0.0f);
            if (Camera.main.gameObject.transform.position.x >= stMove)
            {
                StopCamera = false;
                PCont.enabled = true;
                nCheck++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isCheck)
        {
            JudgeCheck(collision.collider);
            StopCamera = true;
            //CameraMoveOrder();
            Debug.Log("Collision : CheckPoint");
        }
    }

    //private void CameraMoveOrder()
    //{
    //    if (!StopCamera)
    //    {
    //        StopCamera = true;
    //    }
    //    else if (StopCamera)
    //    {
    //        StopCamera = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isCheck)
        {
            JudgeCheck(collision);
        }
    }

    void JudgeCheck(Collider2D colCheck)
    {
        if(colCheck.gameObject.tag == "Player")
        {
            // キャラクターの動きを止める
            PCont = colCheck.GetComponent<PlayerController>();
            PCont.enabled = false;
        }
    }
}
