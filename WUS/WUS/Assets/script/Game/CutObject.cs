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
    public static int MAX_CUTOBJECT = 15;
    public GameObject[] m_CutObject = new GameObject[MAX_CUTOBJECT];
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Cut_Object")
        {
            
        }
        else
        {
            m_CutObject = GameObject.FindGameObjectsWithTag("Cut_Object");
        }
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slice_Star")
        {
            this.gameObject.SetActive(false);
        }

    }

    public void ResetObject()
    {
        if (this.gameObject.tag != "Cut_Object")
        {
            int i = 0;
            for (i = 0; i < m_CutObject.Length; i++)
            {
                if (m_CutObject[i] != null)
                {
                    m_CutObject[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
