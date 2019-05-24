//======================================================
//　　　DropObject
//CutObjectにつながっているオブジェクトにつける
//
//Update内の  Gameobject.Find  の()の中身をCut_Objectのタグが付いているオブジェクト名に変えれば使える
//CutObjectとDropObjectの末尾が同じ数字のものが動作する　　例 Rope1 DropObject1
//CutObjectとDropObjectのオブジェクト名それぞれ末尾の数字以外同じでお願いします…　　例　Rope1 Rope2 Rope3 ......
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
    // Start is called before the first frame update
    void Start()
    {
        m_Name = this.gameObject.name;
        int Lenge = m_Name.Length-1;
        m_num = m_Name.Substring(Lenge);
        m_Position = this.transform.position;
        m_Rotation = this.transform.rotation;       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject CutObject = GameObject.Find("CutObject" + m_num);        //ここのGameobject.Findの()の中身をCutObjectのオブジェクト名にする

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(m_Position.x, pos.y, m_Position.z);
        if (CutObject == null)
        {
           
            Rigidbody2D rd = GetComponent<Rigidbody2D>();
            rd.gravityScale = 1;
        }
        else
        {
            this.transform.position = m_Position;
            this.transform.rotation = m_Rotation;
        }
    }

    public void Resetobject()
    {
        this.gameObject.transform.position = m_Position;
        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        rd.gravityScale = 1;
    }
}
