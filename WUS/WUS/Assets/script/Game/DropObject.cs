//======================================================
//　　　DropObject
//  CutObjectにつながっているオブジェクトにつける
// 
// 概要
//  Update内の  Gameobject.Find  の()の中身をCut_Objectのタグが付いているオブジェクト名に変えれば使える
//  CutObjectとDropObjectの末尾が同じ数字のものが動作する　　例 Rope1 DropObject1
//  CutObjectとDropObjectのオブジェクト名それぞれ末尾の数字以外同じでお願いします…　　例　Rope1 Rope2 Rope3 ......
//======================================================
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DropObject : MonoBehaviour
{
    string m_num;
    string m_Name;
    Vector3 m_Position;
    Quaternion m_Rotation;
    public static int MAX_DROPOBJECT = 15;
    public GameObject[] m_DropObject = new GameObject[MAX_DROPOBJECT];
    bool m_bReset = false;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Drop_Object")
        {
            m_Name = this.gameObject.name;
            int Lenge = m_Name.Length - 1;
            m_num = m_Name.Substring(Lenge);
            m_Position = this.transform.position;
            m_Rotation = this.transform.rotation;
        }
        else
        {
            m_DropObject = GameObject.FindGameObjectsWithTag("Drop_Object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Drop_Object")
        {
            GameObject CutObject = GameObject.Find("CutObject" + m_num);

            if (CutObject == null)
            {
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //           Rigidbody2D rd = GetComponent<Rigidbody2D>();
                //           rd.gravityScale = 1;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

                //         this.transform.position = m_Position;
                //         this.transform.rotation = m_Rotation;
            }

            if (m_bReset == true)
            {
                this.gameObject.transform.rotation = m_Rotation;
                this.gameObject.transform.position = m_Position;
                m_bReset = false;
            }
        }
    }
    public void Resetobject()
    {
        if (this.gameObject.tag != "Drop_Object")
        {
            int i = 0;
            for (i = 0; i < m_DropObject.Length; i++)
            {
                if (m_DropObject[i] != null)
                {
                    m_DropObject[i].GetComponent<DropObject>().m_bReset = true;
                }
            }
        } 
    }
}
