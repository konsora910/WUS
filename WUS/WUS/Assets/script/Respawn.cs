using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Transform respawnpoint;
    private GameObject respawn;
    private GameObject[] RespawnArray = new GameObject[3];
    AudioSource audioSource;
    public AudioClip sound1;
    public int ChangeRes = 0;
    // Start is called before the first frame update
    void Start()
    {
        // リスポーン地点のオブジェクトを読み込む（配列になってないのは許せ...。）
        RespawnArray[0] = GameObject.Find("Respawn");
        RespawnArray[1] = GameObject.Find("Respawn2");
        RespawnArray[2] = GameObject.Find("Respawn3");
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        // 
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
        if (other.gameObject.tag == "Gimic")
        {
            GameObject pc = GetComponent<PlayerController>().gameObject;
            ReturnPoint(pc);

        }
    }

    // キャラクターをリスポーン地点に戻す
    public void ReturnPoint(GameObject getChar)
    {
        audioSource.PlayOneShot(sound1);
        getChar.transform.position = respawn.transform.position;
    }
    
    public void NumResP()
    {
        ChangeRes++;
    }

    public int GetResPNum()
    {
        return ChangeRes;
    }
}
