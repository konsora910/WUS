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

    // Start is called before the first frame update
    void Start()
    {
        m_Position = this.transform.position;
        m_Rotation = this.transform.rotation;
    }

    // Update is called once per frame
      void Update()
      {
        this.transform.position = m_Position;
              this.transform.rotation = m_Rotation;   
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
        this.gameObject.SetActive(true);
    }
}
