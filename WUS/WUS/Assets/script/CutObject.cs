//=========================================================
//　    CutObject
//星(スライス)に当たったら消えるオブジェクトにつける
//
//特にいじるところはない
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slice_Star")
        {
            this.gameObject.SetActive(false);
        }

    }
}
