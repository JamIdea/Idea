using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{

    public GameObject Player;
    public float velocity;
    private bool attachedToCamera;
    // Use this for initialization
    void Start()
    {
        attachedToCamera = true;
        StartCoroutine("BeginPlayerAnimation");
    }

    IEnumerator BeginPlayerAnimation()
    {
        Debug.Log("begin");
        yield return new WaitForSeconds(1);
        Player.GetComponent<Animator>().Play("JumpingPlayer");
        Debug.Log("wait 1");
        Player.GetComponent<PlayerBehaviourScript>().Moving = false;
        yield return new WaitForSeconds(2);
        AttachCameraToRock();
        Player.GetComponent<Animator>().Play("RuningPlayer");
        Debug.Log("WAIT 2");
        attachedToCamera = false;
        Player.GetComponent<PlayerBehaviourScript>().Moving = true;
    }

    private void AttachCameraToRock()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attachedToCamera && Player.GetComponent<PlayerBehaviourScript>().Moving)
        {
            var tmpPosition = Camera.main.transform.localPosition;
            tmpPosition.x += velocity;
            Camera.main.transform.localPosition = tmpPosition;
        }

    }
}
