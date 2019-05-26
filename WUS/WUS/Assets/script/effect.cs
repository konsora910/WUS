using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem particle;
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        particle.Stop();
       
    }

    // Update is called once per frame
    void Update()
    {
        particle.Play();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Explosion_Star")
        {
            //         audioSource.PlayOneShot(sound1);
            for(float i = 0f; i < 2.16f; i += 0.11f)
            {
                particle.Play();

            }
            particle.Clear();
            this.gameObject.SetActive(false);
            //         particle.Stop();
        }

    }

    public void ResetObject()
    {
        particle.Clear();
        this.gameObject.SetActive(true);
    }
}
