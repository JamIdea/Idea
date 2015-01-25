using UnityEngine;
using System.Collections;

public class ColisionFuego : MonoBehaviour {

	// Use this for initialization
    Animator ani;
	void Start () {
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D colision) {
        Debug.Log("Colisiono - " + colision.gameObject.name);
        if (colision.gameObject.name == "Cubeta")
        {
            ani.SetBool("Apagar", true);
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(colision.transform.parent.gameObject);
        }
        else if (colision.gameObject.name == "Player")
        {
            Die();
        }
    }

    void Die()
    {
        //temporal
        Reset();
    }

    void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
}
