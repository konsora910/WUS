using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSelect : MonoBehaviour
{
    //星の総数
    public GameObject[] gameObjectArray = new GameObject[20];

    //クリックしたオブジェクト
    GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        clickedGameObject = null;
        int count = 0;

        foreach (Transform child in transform)
        {
            gameObjectArray[count] = child.gameObject;
            gameObjectArray[count].GetComponent<StarCnontroller>().enabled = false;
            //     Debug.Log("Child[" + count + "]:" + child.name);
            count++;
        }

       // gameObjectArray[1].GetComponent<StarCnontroller>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }
            for(int i=0; i<20;i++)
            {
              //  gameObjectArray[i].GetComponent<StarCnontroller>().enabled = false;
                if (gameObjectArray[i]== clickedGameObject)
                {
                    clickedGameObject.GetComponent<StarCnontroller>().enabled = true;
                    //clickedGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else if(gameObjectArray[i] != clickedGameObject)
                {
                    gameObjectArray[i].GetComponent<StarCnontroller>().enabled = false;
                }
            }
            
            Debug.Log(clickedGameObject);
        }
    }
}
