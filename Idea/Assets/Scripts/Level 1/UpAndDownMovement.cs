using UnityEngine;
using System.Collections;

public class UpAndDownMovement : MonoBehaviour {

    public bool Visible;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.SetActive(Visible);
	}
}
