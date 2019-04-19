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
    private FixedJoint fixedjoint;
    // enumから星がトリガーを判断するかの判定用
    private Mode mode;
    // 刺さった判定
    private bool isSticking;
    private float breakForce = 1200.0f;// 設定した数値以上の力が加わると外れる
    private float breakTorque = 1200.0f;

    // Start is called before the first frame update
    void Start()
    {
        // コライダーから「トリガー」を取得できるか判断する
        if (mode == Mode.collision)
        {
            GetComponentInChildren<Collider>().isTrigger = false;
        }else if (mode == Mode.trigger)
        {
            GetComponentInChildren<Collider>().isTrigger = true;
        }
    }

    // 衝突したと判断したら呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        if (!isSticking)
        {
            JudgeWall(collision.collider);
        }
    }

    // 接触していない判断
    private void OnTriggerEnter(Collider col)
    {
        if (!isSticking)
        {
            JudgeWall(col);
        }
    }

    // 壁かどうかの判断してジョイント設定をする
    void JudgeWall(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if(fixedjoint==null)
            {
                gameObject.AddComponent<FixedJoint>();
                fixedjoint = GetComponent<FixedJoint>();
                fixedjoint.connectedBody = col.gameObject.GetComponent<Rigidbody>();
                fixedjoint.breakForce = breakForce;
                fixedjoint.breakTorque = breakTorque;
                isSticking = true;
                GetComponent<Rigidbody>().velocity = Vector3.zero;// 重力の影響をなくす
                GetComponent<Rigidbody>().Sleep();// その場で動きが止まる
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
