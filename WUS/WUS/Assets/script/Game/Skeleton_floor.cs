//=============================================
//    ギミック　星を針の上に落したとき
//
//     概要
//     星を張りの上に落としたときにできる床
//=============================================

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Skeleton_floor : MonoBehaviour
{
    bool m_bHit = false;
    public static int MAX_SKELETONOBJECT = 15;
    public GameObject[] m_SkeletonObject = new GameObject[MAX_SKELETONOBJECT];
    bool m_bReset = false;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Skeleton_floor")
        {
            m_bReset = false;
            m_bHit = false;
        }
        else
        {
            m_SkeletonObject = GameObject.FindGameObjectsWithTag("Skeleton_floor");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Skeleton_floor")
        {
            if (m_bReset == true)
            {
                BoxCollider2D Collider = GetComponent<BoxCollider2D>();

                Collider.isTrigger = true;
                Collider.size = new Vector2(1.0f, 0.1f);
                Collider.offset = new Vector2(0.0f, -0.7f);
                m_bReset = false;
                m_bHit = false;
            }
            else if (m_bHit == true && m_bReset == false)
            {
                BoxCollider2D Collider = GetComponent<BoxCollider2D>();

                Collider.isTrigger = false;
                Collider.size = new Vector2(1.0f, 0.05f);
                Collider.offset = new Vector2(0.0f, 0.5f);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.tag == "Skeleton_floor")
        {
            if (col.gameObject.tag == "Star")
            {
                m_bHit = true;
            }
        }
    }

    public void ResetSkeltonBlock()
    {
        if (this.gameObject.tag != "Skeleton_floor")
        {
            int i = 0;
            for (i = 0; i < m_SkeletonObject.Length; i++)
            {
                if (m_SkeletonObject[i] != null)
                {
                    m_SkeletonObject[i].GetComponent<Skeleton_floor>().m_bReset = true;
                }
            }
        }
    }
}