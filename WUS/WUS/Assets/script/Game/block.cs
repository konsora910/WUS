using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public static int MAX_BLOCK = 30;
    public GameObject[] m_BlockObject = new GameObject[MAX_BLOCK];
    bool m_bHit = false;
    bool m_bReset = false;
    Vector3 m_startPos;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "block")
        {
            m_bReset = false;
            m_bHit = false;
            this.gameObject.transform.position -= new Vector3(0.0f, 20.0f, 0.0f);
            m_startPos = this.gameObject.transform.position;
        }
        else
        {
            m_BlockObject = GameObject.FindGameObjectsWithTag("block");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_bReset == true)
        {
            if (this.gameObject.transform.position != m_startPos)
            {
                this.gameObject.transform.position += new Vector3(0.0f, -20.0f, 0.0f);
            }
            m_bReset = false;
            m_bHit = false;
        }
        else if (m_bHit == true && m_bReset == false)
        {
            this.gameObject.transform.position += new Vector3(0.0f, 20.0f, 0.0f);
            m_bHit = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Star")
        {
            m_bHit = true;
        }
    }

    public void ResetBlock()
    {
        int i = 0;
        for(i = 0; i < m_BlockObject.Length; i++)
        {
            if(m_BlockObject[i] != null)
            {
                m_BlockObject[i].GetComponent<block>().m_bReset = true;
            }
        }
    }
}