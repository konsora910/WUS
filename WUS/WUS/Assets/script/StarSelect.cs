﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSelect : MonoBehaviour
{
    //星の総数
    public GameObject[] gameObjectArray = new GameObject[20];
    //保存
    public GameObject[] gameObjectArray2 = new GameObject[20];
    public Vector3[] StarPosition = new Vector3[20];
    public Quaternion[] StarRotation = new Quaternion[20];


    //public Transform[] StarTransform = new Transform[20];

    public int allStar;
    //保存
    public int allStar2;

    //クリックしたオブジェクト
    public GameObject clickedGameObject;

    public bool bSave =false;

        // Start is called before the first frame update
        void Start()
    {

        int count = 0;
        foreach (Transform child in transform)
        {
            gameObjectArray[count] = child.gameObject;
            //gameObjectArray[count].GetComponent<StarCnontroller>().enabled = false;
            gameObjectArray[count].GetComponent<StarCnontroller>().bUse=false;
           

            //     Debug.Log("Child[" + count + "]:" + child.name);
            count++;
        }
        allStar = count;

        if (!bSave)
        {
            
            //gameObjectArray2 = gameObjectArray;
            for(int i=0; i< allStar;i++)
            {
                gameObjectArray2[i] = gameObjectArray[i];
                StarPosition[i] = gameObjectArray[i].transform.position;
                StarRotation[i] = gameObjectArray[i].transform.rotation;
            }
            allStar2 = allStar;
            bSave = true;

        }
        

       // gameObjectArray[1].GetComponent<StarCnontroller>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }


            Debug.Log(clickedGameObject);
        }

        for (int i = 0; i < allStar; i++)
        {
            //  gameObjectArray[i].GetComponent<StarCnontroller>().enabled = false;
            if (gameObjectArray[i] == clickedGameObject)
            {
                //clickedGameObject.GetComponent<StarCnontroller>().enabled = true;
                //clickedGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                gameObjectArray[i].GetComponent<StarCnontroller>().bUse = true;
                
                for (int j = i; j < allStar; j++)
                {
                    gameObjectArray[j] = gameObjectArray[j + 1];

                }
                
                allStar = allStar - 1;



            }
            else
            {
                //gameObjectArray[i].GetComponent<StarCnontroller>().enabled = false;
                gameObjectArray[i].GetComponent<StarCnontroller>().bUse = false;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SetStar();
        }
    }
        

public  void SetStar()
    {
        for (int i = 0; i < allStar2; i++)
        {

            
            gameObjectArray[i] = gameObjectArray2[i];
            gameObjectArray[i].SetActive(true);
            gameObjectArray[i].transform.position = StarPosition[i];
            gameObjectArray[i].transform.rotation = StarRotation[i];
            gameObjectArray[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObjectArray[i].GetComponent<StarCnontroller>().bUse = false;

            clickedGameObject = null;

        }
        allStar = allStar2;
    }
    


}
