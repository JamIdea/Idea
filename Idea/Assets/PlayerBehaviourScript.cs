﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{
    public bool Moving;
    public float velocity;
    public Vector3 speed;
    public Vector3 jumpForce;
    public bool IsRunning = false;
    public bool IsJumping = false;
    public bool IsStarted = false;
    public float JumpFactor = 300;
    public float SpeedFactor = 10;

    Animator animator;

    //Game object names

    string background = "Platform";
    string objectKiller = "ObjectKiller";
    string jumpTransitionName = "NeedJump";
    string finalObjectTag = "FinalObject";
    string NextLevel = "Level4";


    // Use this for initialization
    void Start()
    {
        speed = Vector3.right * SpeedFactor;
        jumpForce = Vector2.up * JumpFactor;
        this.animator = this.GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {
        if (IsStarted)
        {
            if (IsRunning && !IsJumping)
                rigidbody2D.velocity = speed;
            else if (IsRunning && IsJumping)
            {
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
            StartRun();
        }
        else
        {

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == objectKiller)
        {
            Die();
        }

        if (collider.tag == finalObjectTag) //Level finished
        {
            FinishLevell();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == background)
            Jump();
    }

    void StartRun()
    {
        IsStarted = true;
        if (!IsRunning)
        {
            IsRunning = true;
            StopJump();
        }
    }


    void Jump()
    {
        if (!IsJumping)
        {
            IsJumping = true;
            rigidbody2D.AddForce(jumpForce);
            animator.SetBool(this.jumpTransitionName, true);

        }
    }

    void StopJump()
    {
        if (IsJumping)
        {
            IsJumping = false;
            animator.SetBool(this.jumpTransitionName, false);
        }

    }

    void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    void Die()
    {
        //temporal
        Reset();
    }

    void FinishLevell()
    {
        //Application.LoadLevel(NextLevel);
        AutoFade.LoadLevel(NextLevel, 3, 1, Color.black);
    }
    // Use this for initialization
  //  void Start()
  //  {
  //
  //  }
  //
  //  // Update is called once per frame
  //  void Update()
  //  {
  //      if (Moving)
  //          this.transform.localPosition = new Vector3(this.transform.localPosition.x + velocity, this.transform.localPosition.y);
  //  }
} //
