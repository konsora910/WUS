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
    PlayerController PCont;
    private bool StopCamera = false;
    private float MoveX = 0.1f;
    public float MoveLength;
    

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
    
    private void FixedUpdate()
    {
        if(StopCamera)
        {
            Vector3 CameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 0)).normalized;
            Camera.main.transform.forward = CameraForward * MoveX;
            Camera.main.gameObject.transform.position += (Vector3.right * MoveX);
            if (Camera.main.transform.position.x >= MoveLength)
            {
                SwitchCameraMoveOrder();
            }

        }else if(!StopCamera)
        {
            Camera.main.gameObject.transform.position += new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // ほぼメイン関数扱い
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            JudgeCheck(collision.collider);
            SwitchCameraMoveOrder();
            Debug.Log("Collision : CheckPoint_START");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
            if (StopCamera)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                PCont.enabled = false;
            }
            else if (!StopCamera)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                PCont.enabled = true;
            }
        }
    }

    // カメラを動かすフラグを呼ぶごとに切り替える関数（多分冗長）
    void SwitchCameraMoveOrder()
    {
        if (StopCamera)
        {
            StopCamera = false;
        }
        else if (!StopCamera)
        {
            StopCamera = true;
        }
    }
}
