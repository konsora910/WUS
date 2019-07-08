//=========================================================
//       Explosion_Star
//爆発させたい星につける
//
//爆発の範囲を広げたければRADIUSをいじる
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionStar : MonoBehaviour
{
    bool m_bHit = false;                  
    public static float RADIUS = 0.03f;    

    public AudioClip Bomb;
    public GameObject particle;
    public GameObject StarPos;
    private ParticleSystem particle1;
    private AudioSource source;
 
    // Start is called before the first frame update
    void Start()
    {
        particle1 = particle.GetComponent<ParticleSystem>();
        particle1.Stop();
        source = GetComponent<AudioSource>();
        m_bHit = false;
       
    }
    // Update is called once per frame
    void Update()
    {
        particle.gameObject.SetActive(false);
        if (m_bHit)
        {
            StartCoroutine("DeleteObject");     

            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(Bomb);
            GameObject.FindObjectOfType<AudioSource>().volume = 0.1f;
            
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.collider.isTrigger)
        { 
            CircleCollider2D Colliders = GetComponent<CircleCollider2D>();
            particle.gameObject.SetActive(true);
            Instantiate(particle, StarPos.transform.position, Quaternion.identity);
        Colliders.radius = RADIUS;
        m_bHit = true;
    }
        
    }
        private IEnumerator DeleteObject()
    {
        // コルーチンの処理  
        yield return new WaitForSeconds(0.05f);
        m_bHit = false;
        this.gameObject.SetActive(false);
    }
}
