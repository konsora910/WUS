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

    private Mode mode;
    private bool isCheck;
    PlayerController PCont;
    MainCam mcam;
    private bool StopCamera = false;
    

    // Start is called before the first frame update
    void Start()
    {
        if (mode == Mode.collision)
        {
            GetComponentInChildren<Collider2D>().isTrigger = false;
        }else if(mode == Mode.trigger)
        {
            GetComponentInChildren<Collider2D>().isTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isCheck)
        {
            JudgeCheck(collision.collider);
            CameraMoveOrder();
            Debug.Log("Collision : CheckPoint");
        }
    }

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

    void CameraMoveOrder()
    {
        if(StopCamera)
        {
            Camera.main.gameObject.transform.position += new Vector3(1.0f, 0.0f, 0f);
            if(Camera.main.gameObject.transform.position.x>=25.0f)
            {
                StopCamera = true;
            }
        }
    }
}
