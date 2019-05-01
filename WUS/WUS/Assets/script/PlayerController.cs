using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 変数
  //  public float speed;
  //  public float rotation;
  //  public string type;

   public GameObject playerPrefab;
  // public GameObject starPrefab;
  // public GameObject StopObject; // 止めるオブジェクト
    Collision col;
    public float PositionX;
    Rigidbody2D rigid;
    private float speed;
   public bool bHit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
     ///   PositionX = 0.006f;
    }


    // Update is called once per frame
    void Update()
    {
        if(!bHit)
        {
            playerPrefab.transform.position += new Vector3(PositionX, 0f, 0f);


        }
        if(bHit)
        {
            playerPrefab.transform.position -= new Vector3(PositionX, 0f, 0f);
        }
     //   if (!bHit)
     //   {
     //       playerPrefab.transform.position -= new Vector3(PositionX, 0f, 0f);
     //
     //   }
    }
   

    // 衝突したと判断したら呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        bHit ^= false;
    }
    
}
