using UnityEngine;
using System.Collections;

public class cameraMoving : MonoBehaviour {
    public Vector3 newPosition;
    public Transform origin;
    public Transform boton;


    void Awake() {
        newPosition = transform.position;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        movingPosition();
	}
    void movingPosition() {
        Vector3 positionIni = origin.position + new Vector3(0,0,-10);
        Vector3 PositionFinal = boton.position + new Vector3(0, 0, -10);

        if (Input.GetKeyDown(KeyCode.Q)) {
            newPosition = positionIni;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            newPosition = PositionFinal;
        }
        transform.position = Vector3.Lerp(transform.position,newPosition,Time.deltaTime);

    }
}
