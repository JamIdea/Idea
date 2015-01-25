using UnityEngine;
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

    Animator animator;

    //Game object names

    string background = "Platform";
    string objectKiller = "ObjectKiller";
    string jumpTransitionName = "NeedJump";
    string finalObjectTag = "FinalObject";

    string NextLevel = "Level3";


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
            StartRun(gObject);
           
        }
        else
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == objectKiller) {
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

    void StartRun(Collision2D collObject) {
        if (!IsStarted && !IsRunning && IsOverPlatform(collObject))
        {
            IsStarted = true;
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

    bool IsOverPlatform(Collision2D collObject)
    {
        Debug.Log(renderer.bounds.size);
        Vector3 platCenter = collObject.gameObject.renderer.bounds.max;
        Vector3 playerCenter = renderer.bounds.min;
        //float verticalDistance = (playerCenter - platCenter).y;
       // bool isover = verticalDistance > renderer.bounds.size.y * .5;
        bool isover = platCenter.y >= platCenter.y;
        return isover;
    }

    void Reset() {
        AutoFade.LoadLevel(Application.loadedLevel, 1, 1, Color.black);
        //Application.LoadLevel(0);
        
    }

    void Die() {
        //temporal
        Reset();
    }

    void FinishLevell() {
       AutoFade.LoadLevel(NextLevel, 3, 1, Color.black);
        //Application.LoadLevel(3);
        
    }
}
