using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotation;
    public string type;

    public GameObject playerPrefab;
    Collision col;
    public float PositionX;
    Rigidbody rigid;
    private float speed;
    bool bHit = false;
    bool JumpCheck = false;
    int JumpTimeMax = 20;
    int JumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!bHit)
        {
            playerPrefab.transform.position += new Vector3(PositionX, 0f, 0f);

        }
        else
        if (bHit == true)
        {


        }
        jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bHit ^= false;
        if (collision.gameObject.tag == "Star" && !collision.collider.isTrigger)
        {
            if (collision.gameObject.transform.position.y < playerPrefab.transform.position.y - 0.5f)
            {

            }
            else
            {
                JumpCheck = true;
            }
        }

    }
    void jump()
    {
        if (JumpCheck == true)
        {
            JumpTime++;
            if (JumpTime < JumpTimeMax)
            {
                playerPrefab.transform.position += new Vector3(0f, 0.1f, 0f);
            }
            else
            {
                JumpCheck = false;
                JumpTime = 0;
            }
        }
    }

}
