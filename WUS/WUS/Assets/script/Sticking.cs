/*=======================================================
    オブジェクトのタグを識別して固定化する
    参考元：https://gametukurikata.com/program/jointenemy
 ======================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticking : MonoBehaviour
{
    enum Mode
    {
        collision,
        trigger
    };
    private FixedJoint2D fixedjoint;

    private readonly Mode mode;
    public bool isSticking;
    private readonly float breakForce = 1200.0f;
    private readonly float breakTorque = 1200.0f;

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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.isTrigger)
        {
            if (!isSticking)
            {
                JudgeWall(collision.collider);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (!isSticking)
            {
                JudgeWall(col);
            }
        }
    }

    void JudgeWall(Collider2D col)
    {
        
            if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Star"&&!col.isTrigger)
            {
                if (fixedjoint == null)
                {
                    gameObject.AddComponent<FixedJoint2D>();
                    fixedjoint = GetComponent<FixedJoint2D>();
                    fixedjoint.connectedBody = col.gameObject.GetComponent<Rigidbody2D>();
                    fixedjoint.breakForce = breakForce;
                    fixedjoint.breakTorque = breakTorque;
                    isSticking = true;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                    GetComponent<Rigidbody2D>().Sleep();
                
                }
            }
            else if (col.gameObject.tag != "Wall")
            {

            }
    }

    private void OnJointBreak()
    {
        isSticking = false;
    }
}
