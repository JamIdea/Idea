using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{
    public bool Moving;
    public float velocity;

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
        rigidbody2D.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
        this.GetComponent<Animator>().SetBool("NeedJump", true);
    }
}
