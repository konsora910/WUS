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
    // くっつくぜスコープ
    private FixedJoint2D fixedjoint;

    // enumから星がトリガーを判断するかの判定用
    private readonly Mode mode;
    // 刺さった判定
    private bool isSticking;
    private readonly float breakForce = 1200.0f;// 設定した数値以上の力が加わると外れる
    private readonly float breakTorque = 1200.0f;

    // Start is called before the first frame update
    void Start()
    {
        // コライダーから「トリガー」を取得できるか判断する
        if (mode == Mode.collision)
        {
            GetComponentInChildren<Collider2D>().isTrigger = false;
        }
        else if (mode == Mode.trigger)
        {
            GetComponentInChildren<Collider2D>().isTrigger = true;
        }
    }

    // 衝突したと判断したら呼ばれる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSticking)
        {
            JudgeWall(collision.collider);
        }
    }

    // 接触していない判断
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isSticking)
        {
            JudgeWall(col);
        }
    }

    // 壁かどうかの判断してジョイント設定をする
    void JudgeWall(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if (fixedjoint == null)
            {
                gameObject.AddComponent<FixedJoint2D>();
                fixedjoint = GetComponent<FixedJoint2D>();
                fixedjoint.connectedBody = col.gameObject.GetComponent<Rigidbody2D>();
                fixedjoint.breakForce = breakForce;
                fixedjoint.breakTorque = breakTorque;
                isSticking = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;// 重力の影響をなくす

                GetComponent<Rigidbody2D>().Sleep();// その場で動きが止まる
            }
        }else if(col.gameObject.tag != "Wall")
        {

        }
    }

    // ジョイント機能から解除されたら呼ばれる
    private void OnJointBreak()
    {
        isSticking = false;
    }
}
