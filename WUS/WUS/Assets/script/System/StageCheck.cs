using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCheck : MonoBehaviour
{
    public static int StageClearCheck = 0;
    public static int NowStage= 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void ClearStage1()
    {
        StageClearCheck = 1;
    }
    public static void ClearStage2()
    {
        StageClearCheck = 2;
    }
    public static void ClearStage3()
    {
        StageClearCheck = 3;
    }
    public static void ClearStage4()
    {
        StageClearCheck = 4;
    }
    public static void NowStage1()
    {
        NowStage = 1;
    }
    public static void NowStage2()
    {
        NowStage = 2;
    }
    public static void NowStage3()
    {
        NowStage = 3;
    }
    public static void NowStage4()
    {
        NowStage = 4;
    }

}
