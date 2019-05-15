//=========================================================
//      BreakBlock
//爆発星が当たったら消えるオブジェクトにつける
//
//特にいじるところはない
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlok : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  /*  void Update()
    {
        
    }*/
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Explosion_Star")
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
