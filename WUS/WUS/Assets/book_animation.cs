using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_animation : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
    public void StartAnimation()
    {
        animator.SetTrigger("book_animation");
    }
}
