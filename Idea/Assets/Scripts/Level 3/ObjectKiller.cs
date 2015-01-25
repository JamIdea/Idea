using UnityEngine;
using System.Collections;

public class ObjectKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collison) {
        if (collison.gameObject.name == "Player")
        {
            Die();
        }
    }

    void Die() {
        AutoFade.LoadLevel(Application.loadedLevel, 2, 1, Color.black);
    }

}
