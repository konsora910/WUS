//=========================================================
//      BreakBlock
//爆発星が当たったら消えるオブジェクトにつける
//
//
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlok : MonoBehaviour
{
    private 
        Vector3 m_Position;
        Quaternion m_Rotation;
    public static int MAX_BREAKOBJECT = 20;
    public GameObject[] m_BreakObject = new GameObject[MAX_BREAKOBJECT];
    bool m_bReset = false;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "BreakBlock")
        {
            m_Position = this.transform.position;
            m_Rotation = this.transform.rotation;
        }
        else
        {
            m_BreakObject = GameObject.FindGameObjectsWithTag("BreakBlock");
        }
    }

    // Update is called once per frame
      void Update()
      {
        if (this.gameObject.tag == "BreakBlock")
        {
            this.transform.position = m_Position;
            this.transform.rotation = m_Rotation;
        }
      }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Explosion_Star")
        {
            this.gameObject.SetActive(false);
        }
        
    }
    public void ResetObject()
    {
        if (this.gameObject.tag != "BreakBlock")
        {
            int i = 0;
            for (i = 0; i < m_BreakObject.Length; i++)
            {
                if (m_BreakObject[i] != null)
                {
                    m_BreakObject[i].GetComponent<BreakBlok>().gameObject.SetActive(true);
                }
            }
        }
    }
}
