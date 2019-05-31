using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSelect : MonoBehaviour
{
    public GameObject[] gameObjectArray = new GameObject[50];
    public GameObject[] gameObjectArray2 = new GameObject[50];
    public Vector3[] StarPosition = new Vector3[50];
    public Quaternion[] StarRotation = new Quaternion[50];
    public int allStar;
    public int allStar2;
    public GameObject clickedGameObject;
    public bool bSave = false;

    GameObject StarDir;

    // Start is called before the first frame update
    void Start()
    {

        int count = 0;
        foreach (Transform child in transform)
        {
            gameObjectArray[count] = child.gameObject;
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
        StarDir = GameObject.Find("StarDir");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
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
                gameObjectArray[i].GetComponent<StarCnontroller>().bClick = true;
                if (gameObjectArray[i].GetComponent<StarCnontroller>().bDir)
                {
                    StarDir.SetActive(true);
                    StarDir.transform.position = gameObjectArray[i].transform.position;//+new Vector3(-0.6f,1.0f,0f);

                    StarDir.transform.rotation = Quaternion.Euler(0, 0, gameObjectArray[i].GetComponent<StarCnontroller>().angle + 90f);
                }
                else
                {
                    StarDir.SetActive(false);

                }
                if (gameObjectArray[i].GetComponent<StarCnontroller>().bUse)
                {

                    for (int j = i; j < allStar; j++)
                    {
                        gameObjectArray[j] = gameObjectArray[j + 1];

                    }

                    allStar = allStar - 1;
                }
            }
        }

        if (clickedGameObject == null)
        {
            StarDir.SetActive(false);
        }
    }
    public void SetStar()
    {
        for (int i = 0; i < allStar2; i++)
        {

            clickedGameObject = null;

            gameObjectArray[i] = gameObjectArray2[i];
            gameObjectArray[i].SetActive(true);
            gameObjectArray[i].transform.position = StarPosition[i];
            gameObjectArray[i].transform.rotation = StarRotation[i];
            gameObjectArray[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObjectArray[i].GetComponent<StarCnontroller>().bUse = false;
            gameObjectArray[i].GetComponent<StarCnontroller>().bClick = false;

            Destroy(gameObjectArray[i].GetComponent<FixedJoint2D>());
            if (gameObjectArray[i].tag == "Star")
            {
                gameObjectArray[i].GetComponent<Sticking>().isSticking = false;
            }
            clickedGameObject = null;
        }
        allStar = allStar2;
    }
    public void clicknull()
    {
        clickedGameObject = null;
    }

}
