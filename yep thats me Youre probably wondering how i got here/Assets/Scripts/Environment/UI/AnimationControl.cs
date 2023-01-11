using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;
    private bool isAnimating = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    public void SlideIn()
    {

      

            animator.Play("Slide_In");

        
    }

    public void StopAnimation()
    {

        animator.enabled = false;

    }
    public void SlideOut()
    {



        animator.Play("Slide_Out");


    }
    public void StartAnimation()
    {

        animator.enabled = true;

    }
}
