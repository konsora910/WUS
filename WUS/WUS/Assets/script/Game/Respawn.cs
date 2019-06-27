using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject respawn;
    private GameObject[] RespawnArray = new GameObject[3];

    public int ChangeRes = 0;

    // Start is called before the first frame update
    void Start()
    {
        RespawnArray[0] = GameObject.Find("Respawn");
        RespawnArray[1] = GameObject.Find("Respawn2");
        RespawnArray[2] = GameObject.Find("Respawn3");
    }
    private void Update()
    {
        
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
            GetComponent<AudioSource>().Play();
        }
    }

    public void ReturnPoint(GameObject getChar)
    {
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
