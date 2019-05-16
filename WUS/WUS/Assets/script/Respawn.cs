using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float power;
    private Transform respawnpoint;
    public GameObject respawn;
    // Start is called before the first frame update
    void Start()
    {
        respawnpoint = respawn.transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ReturnPoint(other.gameObject);
            GetComponent<AudioSource>().Play();
        }
    }

    // キャラクターをリスポーン地点に戻す
    private void ReturnPoint(GameObject getChar)
    {
        getChar.transform.position = respawnpoint.position;
    }
}
