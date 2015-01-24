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
        BeginPlayerAnimation();
    }

    IEnumerator BeginPlayerAnimation()
    {
        yield return new WaitForSeconds(1);
        Player.GetComponent<Animator>().Play("JumplingPlayer");
        yield return new WaitForSeconds(1);
        AttachCameraToRock();
        Player.GetComponent<Animator>().Play("RuningPlayer");
    }

    private void AttachCameraToRock()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attachedToCamera)
        {
            var tmpPosition = Camera.main.transform.localPosition;
            tmpPosition.x += velocity;
        }

    }
}
