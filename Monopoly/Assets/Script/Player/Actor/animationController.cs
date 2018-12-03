using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    public bool running;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("running" ,running);
        /*
        if ( Input.GetKey("up") )
        {
            animator.SetBool("running" ,true);
        }
        if ( Input.GetKey("down") )
        {
            animator.SetBool("running" ,false);
        }
        */
    }
}
