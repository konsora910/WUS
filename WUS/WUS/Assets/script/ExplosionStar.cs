using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionStar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 /*   void Update()
    {
        
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        
        CircleCollider2D Collider = GetComponent<CircleCollider2D>(); //コライダー取得

        Collider.isTrigger = false;                     //あたり判定の透過解除
        Collider.radius = Collider.radius * 2.0f;
        this.gameObject.SetActive(false);
    }
}
