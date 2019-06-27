//=========================================================
//　      SliceStar
//
//  概要
//　切る星につける
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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (col.gameObject.tag == "Cut_Object")
            {
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(Cut);
                GameObject.FindObjectOfType<AudioSource>().volume = 0.8f;
            }
            else
            {
                this.gameObject.SetActive(false);
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(NoCut);
            }
        }
    }
}
