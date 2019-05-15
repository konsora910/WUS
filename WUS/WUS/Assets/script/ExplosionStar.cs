﻿//=========================================================
//       Explosion_Star
//爆発させたい星につける
//
//爆発の範囲を広げたければRADIUSをいじる
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionStar : MonoBehaviour
{
    bool m_bHit = false;                    //オブジェクトに当たったかどうか
    public static float RADIUS = 0.03f;     //爆発の範囲変更はここの数値　元のサイズは0.01

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(m_bHit)
        {
            StartCoroutine("DeleteObject");      //約1フレーム後にDeleteObjectを実行する

        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        CircleCollider2D Colliders = GetComponent<CircleCollider2D>();

        Colliders.radius = RADIUS;       
        m_bHit = true;
    }

        private IEnumerator DeleteObject()
    {
        // コルーチンの処理  
        yield return new WaitForSeconds(0.05f);
        this.gameObject.SetActive(false);
    }
}
