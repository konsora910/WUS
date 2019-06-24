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

    public void StartAnimation()
    {
        animator.SetTrigger("book_animation");
    }
}
