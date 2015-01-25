using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour
{

    public Vector3 speed;
    public Vector3 jumpForce;
    public bool IsRunning = false;
    public bool IsJumping = false;
    public bool IsStarted = false;
    public float JumpFactor;
    public float SpeedFactor;

    Animator animator;

    //Game object names

    string background = "Platform";
    string objectKiller = "ObjectKiller";
    string jumpTransitionName = "NeedJump";
    string finalObjectTag = "FinalObject";

    public string NextLevel = "Level3";


    // Use this for initialization
    void Start()
    {
        IsStarted = true;
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
            this.transform.localPosition += new Vector3(SpeedFactor, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D gObject)
    {
        StartRun(gObject);

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

    void StartRun(Collision2D collObject)
    {

        IsRunning = true;
        StopJump();

    }


    void Jump()
    {
        if (!IsJumping)
        {
            IsJumping = true;

            rigidbody2D.AddForce(Vector3.up * JumpFactor, ForceMode2D.Impulse);
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
        AutoFade.LoadLevel(Application.loadedLevel, 1, 1, Color.black);
        //Application.LoadLevel(0);

    }

    void Die()
    {
        //temporal
        Reset();
    }

    void FinishLevell()
    {
        AutoFade.LoadLevel(NextLevel, 3, 1, Color.black);
        //Application.LoadLevel(3);

    }
}
