//=========================================================
//　      SliceStar
//切る星につける
//
//特にいじるところはない
//=========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceStar : MonoBehaviour
{

    AudioSource Audiosouce;
    public AudioClip Cut;
    public AudioClip NoCut;
    // Start is called before the first frame update
    void Start()
    {
        Audiosouce = GetComponent<AudioSource>();
    }

    /*  // Update is called once per frame
      void Update()
      {

      }
      */
    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag == "Cut_Object" || col.gameObject.tag == "Star")
        //{
        //    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(Cut);
        //}
        if (!col.isTrigger)
        {
            if (col.gameObject.tag == "Cut_Object")
            {
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(Cut);
            }
            else
            {
                this.gameObject.SetActive(false);
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(NoCut);
            }
        }
    }
}
