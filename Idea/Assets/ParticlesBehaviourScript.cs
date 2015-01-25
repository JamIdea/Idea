using UnityEngine;
using System.Collections;

public class ParticlesBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        particleSystem.renderer.sortingLayerName = "Player";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
