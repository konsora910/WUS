//=========================================================
//      
//    チェックポイント単体の操作スクリプト
//
//=========================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    enum Mode
    {
        collision,
        trigger
    };
    private readonly float tX = 0.5f;
    private readonly Mode mode;
    private bool StopCamera = false;
    public float stMove = 0.0f;
    public AudioClip CPSE;
    public AudioSource AudioSource;
    PlayerController PCont;
    Respawn Rcnt;
    GameObject CallPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (mode == Mode.collision)
        {
            GetComponentInChildren<Collider2D>().isTrigger = false;
        }
        else if (mode == Mode.trigger)
        {
            GetComponentInChildren<Collider2D>().isTrigger = true;
        }
        CallPlayer = GameObject.Find("player");
    }
    private void FixedUpdate()
    {
        if (StopCamera)
        {
            Transform CameraMovePoint = Camera.main.gameObject.transform;
            CameraMovePoint.Translate(tX, 0.0f, 0.0f);
            if (CameraMovePoint.position.x >= stMove)
            {
                StopCamera = false;
                PCont.enabled = true;
                Destroy(this.gameObject);
                CallPlayer.GetComponent<Respawn>().NumResP();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            JudgeCheck(collision.collider);
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(CPSE);
            GameObject.FindObjectOfType<AudioSource>().volume = 0.5f;
            StopCamera = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            JudgeCheck(collision);
        }
    }
    void JudgeCheck(Collider2D colCheck)
    {
        if (colCheck.gameObject.tag == "Player")
        {
            PCont = colCheck.GetComponent<PlayerController>();
            PCont.enabled = false;
        }
    }
    public void StmoveSet(float move)
    {
        stMove = move;
    }
}
