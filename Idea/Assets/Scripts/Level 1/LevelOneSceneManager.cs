using UnityEngine;
using System.Collections;

public class LevelOneSceneManager : MonoBehaviour
{


    public GameObject Player;
    public float position;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var tmpPosition = Camera.main.transform.localPosition;
        tmpPosition.x = Player.transform.localPosition.x + position;
        Camera.main.transform.localPosition = tmpPosition;
    }
}
