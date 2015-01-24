using UnityEngine;
using System.Collections;

public class CortarCuerda : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            //this.transform.rigidbody2D.gravityScale = 1;
            Destroy(this.gameObject.GetComponent<HingeJoint2D>());
            //Destroy(this.gameObject.hingeJoint);
            //Destroy(this.gameObject);
        }
    }
}
