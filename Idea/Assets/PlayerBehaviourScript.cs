using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{
    public bool Moving;
    public float velocity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
            this.transform.localPosition = new Vector3(this.transform.localPosition.x + velocity, this.transform.localPosition.y);
    }
}
