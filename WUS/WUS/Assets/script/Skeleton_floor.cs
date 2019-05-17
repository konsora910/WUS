using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


/*=============================================
    ギミック　星を針の上に落したとき
=============================================*/
public class Skeleton_floor : MonoBehaviour
{
    bool m_bHit = false;        //ギミックが作動したら
    bool m_bReset = false;
    // Start is called before the first frame update
    void Start()
    {
        m_bReset = false;
        m_bHit = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (m_bHit == false && m_bReset == true)
        {
            BoxCollider2D Collider = GetComponent<BoxCollider2D>(); //コライダー取得

            Collider.isTrigger = true;                       //あたり判定の透過解除
            Collider.size = new Vector2(1.0f, 0.1f);         //サイズをもとのブロックの大きさに
            Collider.offset = new Vector2(0.0f, -0.2f);      //あたり判定の中心をもとのボックスの位置に
            m_bReset = false;
            m_bHit = false;
        }
        else if (m_bHit == true && m_bReset == false)
        {
            BoxCollider2D Collider = GetComponent<BoxCollider2D>(); //コライダー取得

            Collider.isTrigger = false;                      //あたり判定の透過解除
            Collider.size = new Vector2(1.0f, 0.05f);        //サイズをもとのブロックの大きさに
            Collider.offset = new Vector2(0.0f, 0.5f);       //あたり判定の中心をもとのボックスの位置に
            m_bHit = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            ResetSkeltonBlock();
        }
    }

    //衝突判定処理
    void OnTriggerEnter2D(Collider2D col)
    {
        //星と当たったら
        if (col.gameObject.tag == "Star")
        {
            m_bHit = true;
        }
    }

    public void ResetSkeltonBlock()
    {
        m_bReset = true;
    }
}



