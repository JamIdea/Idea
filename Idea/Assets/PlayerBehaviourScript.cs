using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{
    public bool Moving;
    public float velocity;
    public float jumpFactor;
    string finalObjectTag = "FinalObject";
    public string NextLevel;

    //Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            this.transform.localPosition += new Vector3(velocity, 0);
            this.GetComponent<Animator>().SetBool("NeedJump", false);
        }

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        rigidbody2D.AddForce(Vector3.up * jumpFactor, ForceMode2D.Impulse);
        this.GetComponent<Animator>().SetBool("NeedJump", true);
        
        if (collider.tag == finalObjectTag) //Level finished
        {
            FinishLevell();
        }
    }

    void FinishLevell()
    {
        AutoFade.LoadLevel(NextLevel, 3, 1, Color.black);
        //Application.LoadLevel(3);

    }
}
