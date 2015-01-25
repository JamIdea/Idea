using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject Hand;
    public GameObject Nut;
    public float velocity;
    public float position;
    private bool attachedToCamera;
    // Use this for initialization
    void Start()
    {
        attachedToCamera = true;
        position = Camera.main.transform.localPosition.x - Player.transform.localPosition.x;

    }

    void OnTriggerEnter2D(Collider2D element)
    {
        if (element.name == "Player")
            StartCoroutine("BeginPlayerAnimation");
    }

    IEnumerator BeginPlayerAnimation()
    {
        Debug.Log("begin");
        yield return new WaitForSeconds(1);
        Player.GetComponent<Animator>().Play("ScaredPlayer");
        Debug.Log("wait 1");
        Player.GetComponent<PlayerBehaviourScript>().Moving = false;
        Player.rigidbody2D.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        AttachCameraToRock();
        Player.GetComponent<Animator>().Play("RuningPlayer");
        Debug.Log("WAIT 2");
        attachedToCamera = false;
        Nut.rigidbody2D.gravityScale = 0.2f;
        Player.rigidbody2D.gravityScale = 0.00001f;
        Player.transform.Rotate(new Vector3(0, 0, 22f));
        yield return new WaitForSeconds(2.5f);
        Destroy(Hand);
        Player.GetComponent<PlayerBehaviourScript>().Moving = true;
    }

    private void AttachCameraToRock()
    {
        if (Nut != null)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Nut.transform.position + new Vector3(-.04f, -.04f, -10f), Time.deltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 10f, Time.deltaTime);
        }
        else
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Player.transform.position + new Vector3(-.04f, -.04f, -10f), Time.deltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 7f, Time.deltaTime);
        }
        //Camera.main.transform.localPosition = new Vector3(Rock.transform.localPosition.x, Rock.transform.localPosition.y, Camera.main.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (attachedToCamera && Player.GetComponent<PlayerBehaviourScript>().Moving)
        {
            var tmpPosition = Camera.main.transform.localPosition;
            tmpPosition.x = Player.transform.localPosition.x + position;
            Camera.main.transform.localPosition = tmpPosition;
        }
        else if (!attachedToCamera)
        {
            AttachCameraToRock();
        }

    }
}
