//*********************************************************
//　ギミック　ひも
//　星(スライス)に当たったら消える
// 要改造
//*********************************************************
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
            BoxCollider2D Collider = GetComponent<BoxCollider2D>(); //コライダー取得
            
            this.gameObject.SetActive(false);
            
        }

    }
}
