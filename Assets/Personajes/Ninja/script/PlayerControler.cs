using System;
using UnityEngine;



public class PlayerControler : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        moverseHorizontalmente();
        setupSalto();
        
    }

    void setupSalto()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocityY = 20;
        }
    }

    void moverseHorizontalmente()
    {
        rb.linearVelocityX = 0;
        animator.SetInteger("Estado", 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocityX = 10;
            sr.flipX = false;
            animator.SetInteger("Estado", 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocityX = -10;
            sr.flipX = true;
            animator.SetInteger("Estado", 1);
        }
    }
}
