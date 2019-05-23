using System.Collections;
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

    public bool bSave = false;

    //矢印
    GameObject StarDir;
   // GameObject StarDirImg;
    //RectTransform rect;



    // Start is called before the first frame update
    void Start()
    {

        int count = 0;
        foreach (Transform child in transform)
        {
            gameObjectArray[count] = child.gameObject;
            //gameObjectArray[count].GetComponent<StarCnontroller>().enabled = false;
            //gameObjectArray[count].GetComponent<StarCnontroller>().bUse=false;


            //     Debug.Log("Child[" + count + "]:" + child.name);
            count++;
        }
        allStar = count;

        if (!bSave)
        {

            //gameObjectArray2 = gameObjectArray;
            for (int i = 0; i < allStar; i++)
            {
                gameObjectArray2[i] = gameObjectArray[i];
                StarPosition[i] = gameObjectArray[i].transform.position;
                StarRotation[i] = gameObjectArray[i].transform.rotation;
            }
            allStar2 = allStar;
            bSave = true;

        }


        // gameObjectArray[1].GetComponent<StarCnontroller>().enabled = false;

        StarDir = GameObject.Find("StarDir");
       // StarDirImg = GameObject.Find("DirImage");
       // rect = StarDirImg.GetComponent<RectTransform>();



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

           // clickedGameObject = null;
            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            /*
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                clickedGameObject = collition2d.transform.gameObject;
            }
            */



            Debug.Log(clickedGameObject);
        }

        for (int i = 0; i < allStar; i++)
        {
            //  gameObjectArray[i].GetComponent<StarCnontroller>().enabled = false;
            if (gameObjectArray[i] == clickedGameObject)
            {
                gameObjectArray[i].GetComponent<StarCnontroller>().bClick = true;
                if (gameObjectArray[i].GetComponent<StarCnontroller>().bDir)
                {
                    StarDir.SetActive(true);
                    StarDir.transform.position = gameObjectArray[i].transform.position;//+new Vector3(-0.6f,1.0f,0f);
                    
                    StarDir.transform.rotation = Quaternion.Euler(0, 0, gameObjectArray[i].GetComponent<StarCnontroller>().angle+90f); 
                }
                else
                {
                    StarDir.SetActive(false);

                }
                //clickedGameObject.GetComponent<StarCnontroller>().enabled = true;
                //clickedGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                if (gameObjectArray[i].GetComponent<StarCnontroller>().bUse)
                {

                    for (int j = i; j < allStar; j++)
                    {
                        gameObjectArray[j] = gameObjectArray[j + 1];


                    }

                    allStar = allStar - 1;
                }
                //clickedGameObject = null;


            }
            else
            {
                //gameObjectArray[i].GetComponent<StarCnontroller>().enabled = false;
                // gameObjectArray[i].GetComponent<StarCnontroller>().bUse = false;
               // gameObjectArray[i].GetComponent<StarCnontroller>().bClick = false;
            }
        }
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            SetStar();
        }
        */

        if(clickedGameObject==null)
        {
            StarDir.SetActive(false);
        }
    }


    public void SetStar()
    {
        for (int i = 0; i < allStar2; i++)
        {



            gameObjectArray[i] = gameObjectArray2[i];
            gameObjectArray[i].SetActive(true);
            gameObjectArray[i].transform.position = StarPosition[i];
            gameObjectArray[i].transform.rotation = StarRotation[i];
            gameObjectArray[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObjectArray[i].GetComponent<StarCnontroller>().bUse = false;
            gameObjectArray[i].GetComponent<StarCnontroller>().bClick = false;
            // gameObjectArray[i].GetComponent<Rigidbody2D>().WakeUp();
            Destroy(gameObjectArray[i].GetComponent<FixedJoint2D>());

            clickedGameObject = null;

        }
        allStar = allStar2;
    }

    public void clicknull()
    {
        clickedGameObject = null;
    }



}
