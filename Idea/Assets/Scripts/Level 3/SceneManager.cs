using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject Rock;
    public float velocity;
    private bool attachedToCamera;
    private Vector3 OldPosition;
    // Use this for initialization
    void Start()
    {
        OldPosition = Rock.transform.localPosition;
        attachedToCamera = true;
        StartCoroutine("BeginPlayerAnimation");
    }

    IEnumerator BeginPlayerAnimation()
    {
        Debug.Log("begin");
        yield return new WaitForSeconds(1);
        Player.GetComponent<Animator>().Play("ScaredPlayer");
        Debug.Log("wait 1");
        Player.GetComponent<PlayerBehaviourScript>().Moving = false;
        yield return new WaitForSeconds(2);
        AttachCameraToRock();
        Player.GetComponent<Animator>().Play("RuningPlayer");
        Debug.Log("WAIT 2");
        attachedToCamera = false;
        Rock.rigidbody2D.gravityScale = 0.2f;
        Player.GetComponent<PlayerBehaviourScript>().Moving = true;
    }

    private void AttachCameraToRock()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Rock.transform.position + new Vector3(-.04f, -.04f, -10f), Time.deltaTime);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 10f, Time.deltaTime);
        //Camera.main.transform.localPosition = new Vector3(Rock.transform.localPosition.x, Rock.transform.localPosition.y, Camera.main.transform.localPosition.z);
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
        else if (!attachedToCamera)
        {
            AttachCameraToRock();
        }

    }
}
