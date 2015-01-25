using UnityEngine;
using System.Collections;

public class LevelCompletedBehaviour : MonoBehaviour {

    public string NextLevel;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D element) {

        if (element.name == "Player") {
            element.gameObject.GetComponent<Animator>().Play("IdlePlayer");
            element.gameObject.GetComponent<PlayerBehaviourScript>().Moving = false;
            AutoFade.LoadLevel(NextLevel, 3, 1, Color.black);

        }
    }

    
}
