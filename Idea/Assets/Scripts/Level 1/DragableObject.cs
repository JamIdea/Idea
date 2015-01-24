using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DragableObject : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    private string character = "Player";

    public bool DragEnabled = true;

    public bool EnableX = true;
    public bool EnableY = true;


    void OnMouseDown()
    {
        
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (DragEnabled)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(EnableX?curPosition.x:transform.position.x, EnableY? curPosition.y:transform.position.y, curPosition.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //if is a character this object must not move
        if (collider.gameObject.name == character)
        {
            DragEnabled = false;

        }
    
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
