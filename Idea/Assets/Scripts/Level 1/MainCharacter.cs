﻿using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour
{

    public Vector3 speed;
    public Vector3 jumpForce;
    public bool IsRunning = false;
    public bool IsJumping = false;
    public bool IsStarted = false;
    public float JumpFactor = 300;
    public float SpeedFactor = 10;


    //Game object names

    string background = "BackGround";
    string objectKiller = "ObjectKiller";

    // Use this for initialization
    void Start()
    {
        speed = Vector3.right * SpeedFactor;
        jumpForce = Vector2.up * JumpFactor;

    }



    // Update is called once per frame
    void Update()
    {


            
    }

    void FixedUpdate()
    {
        if (IsStarted) {
            if (IsRunning && !IsJumping) 
                rigidbody2D.velocity = speed;
            else if(IsRunning&&IsJumping) {
                IsRunning = false;
                IsStarted = false;
                rigidbody2D.AddForce(jumpForce);
            }

            
        }

        
       
    }

    void OnCollisionEnter2D(Collision2D gObject)
    {
        if (!IsStarted)
        {
            IsStarted = true;
            IsJumping = false;
            StartRun();
        }
        else
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == objectKiller) {
            Die();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == background)
            Jump();
    }

    void StartRun() {
        if (!IsRunning) {
            IsRunning = true;            
        }
    }

    
    void Jump()
    {
        if (!IsJumping)
        {
            IsJumping = true;
            rigidbody2D.AddForce(jumpForce);
        }
    }

    void StopJump()
    {
        if (IsJumping)
            IsJumping = false;
    }

    void Die() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
