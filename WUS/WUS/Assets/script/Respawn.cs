using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject respawn;
    private GameObject[] RespawnArray = new GameObject[3];

    private int ChangeRes = 0;// リスポーン地点切り替え変数

    // Start is called before the first frame update
    void Start()
    {
        // リスポーン地点のオブジェクトを読み込む（配列になってないのは許せ...。）
        RespawnArray[0] = GameObject.Find("Respawn");
        RespawnArray[1] = GameObject.Find("Respawn2");
        RespawnArray[2] = GameObject.Find("Respawn3");
    }
    private void Update()
    {
        // リスポーン地点の切り替えを行う処理内容（switch文）
        switch (ChangeRes)
        {
            case 0:
                respawn = RespawnArray[0];
                break;
            case 1:
                respawn = RespawnArray[1];
                break;
            case 2:
                respawn = RespawnArray[2];
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // プレイヤーがGimicタグのついたオブジェクトに当たると通る
        if (other.gameObject.tag == "Gimic")
        {
            GameObject pc = GetComponent<PlayerController>().gameObject;
            ReturnPoint(pc);
            //GetComponent<AudioSource>().Play();
        }
    }

    // キャラクターをリスポーン地点に戻す
    public void ReturnPoint(GameObject getChar)
    {
        getChar.transform.position = respawn.transform.position;
    }
    
    public void NumResP()
    {// 呼び出されればリスポーン地点の切り替えになる（別スクリプトによる処理）
        ChangeRes++;
    }

    public int GetResPNum()
    {// UI用Get関数
        return ChangeRes;
    }
}
