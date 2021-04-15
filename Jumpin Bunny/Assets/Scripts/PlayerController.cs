﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isOnGround = IsOnGround();
        print("is Ground = " + isOnGround);
        animator.SetBool("isGrounded", isOnGround);
        if ((Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)) && isOnGround)
        {
            //print("Left button or space or w pressed!");
            jump();
        }

        /*if(Input.GetKeyDown(KeyCode.D))  
        {
            rigidBody.AddForce(new Vector2(runSpeed, 0), ForceMode2D.Impulse);
            //transform.position = new Vector2(transform.position.x + runSpeed * Time.deltaTime, rigidBody.position.y);
        }*/
        if(rigidBody.velocity.x < runSpeed)
        {
            rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
        }
       
    }

    void jump()
    {
        rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }
    bool IsOnGround()
    {
        //print("Mask = " + groundLayerMask);
        return Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value);
    }
}
