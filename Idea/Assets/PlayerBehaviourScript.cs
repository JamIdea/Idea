using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x + 0.1f, this.transform.localPosition.y);
    }
}
