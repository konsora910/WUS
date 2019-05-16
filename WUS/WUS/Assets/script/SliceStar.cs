//=========================================================
//　      SliceStar
//切る星につける
//
//特にいじるところはない
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceStar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  /*  // Update is called once per frame
    void Update()
    {
        
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Cut_Object" || col.gameObject.tag == "Star")
        {

        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
