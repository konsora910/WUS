using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


/*=============================================
    ギミック　星を針の上に落したとき
=============================================*/
public class Skeleton_floor : MonoBehaviour
{
    //衝突判定処理
    void OnTriggerEnter2D(Collider2D col)
    {
        //星と当たったら
        if (col.gameObject.tag == "Star")
        {
            BoxCollider2D Collider = GetComponent<BoxCollider2D>(); //コライダー取得

            Collider.isTrigger = false;                     //あたり判定の透過解除
            Collider.size = new Vector2(1.0f, 0.05f);        //サイズをもとのブロックの大きさに
            Collider.offset = new Vector2(0.0f, 0.5f);      //あたり判定の中心をもとのボックスの位置に

        }
        
    }
}



