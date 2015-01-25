using UnityEngine;
using System.Collections;

public class ScenarioBehaviourScript : MonoBehaviour {

    public float Step;
    public bool IsMoving;
    public float MaxPosition;
    public float MinPosition;

	public GameObject Player;
	public GameObject Nut;
	public float velocity;
	private bool attachedToCamera;
	
	// Use this for initialization
	void Start () {
		StartCoroutine ("BeginPlayerAnimation");
		attachedToCamera = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (attachedToCamera && Player.GetComponent<PlayerBehaviourScript>().Moving)
		{
			AttachCameraToPlayer();
		}
		else if (!attachedToCamera)
		{
			AttachCameraToNut();
		}
	}
	
	IEnumerator BeginPlayerAnimation()
	{
		Debug.Log("begin");
		Player.GetComponent<PlayerBehaviourScript>().Moving = false;
		yield return new WaitForSeconds(3);
		//Player.GetComponent<Animator>().Play("ScaredPlayer");
		
		Debug.Log("wait 1");
		Player.GetComponent<PlayerBehaviourScript>().Moving = true;
		attachedToCamera = true;
		//Player.GetComponent<Animator>().Play("RuningPlayer");
		
	}
	
	private void AttachCameraToPlayer()
	{
		if (Player != null)
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Player.transform.position, Time.deltaTime);
		}
	}
	
	private void AttachCameraToNut()
	{
		if (Nut != null)
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Nut.transform.position, Time.deltaTime);
		}
	}
}
