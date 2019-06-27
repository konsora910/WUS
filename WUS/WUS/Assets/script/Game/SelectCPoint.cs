using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCPoint : MonoBehaviour
{
    // チェックポイントの最大数
    private GameObject[] checkPointArray = new GameObject[2];
    private int Points;

    //=================================================
    //  動的に変動可能変数群（カメラの移動距離）
    public float CPMoveNum1;
    public float CPMoveNum2;
    //=================================================

    private int numCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        int nPoint = 0;
        foreach (Transform child in transform)
        {
            checkPointArray[nPoint] = child.gameObject;
            checkPointArray[nPoint].GetComponent<CheckPoint>();

            nPoint++;
        }
        Points = nPoint;
        checkPointArray[0] = GameObject.Find("checkpoint");
        checkPointArray[1] = GameObject.Find("checkpoint2");

    }

    // Update is called once per frame
    void Update()
    {
        switch (numCheck)
        {
            case 0:
                checkPointArray[0].GetComponent<CheckPoint>().StmoveSet(CPMoveNum1);
                break;
            case 1:
                checkPointArray[1].GetComponent<CheckPoint>().StmoveSet(CPMoveNum1 + CPMoveNum2);
                break;
            default:
                break;
        }
        numCheck++;
    }
}
