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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slice_Star")
        {
            this.gameObject.SetActive(false);
        }

    }

    public void ResetObject()
    {
        this.gameObject.SetActive(true);
    }
}
