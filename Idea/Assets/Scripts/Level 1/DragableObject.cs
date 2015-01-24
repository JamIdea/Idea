using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DragableObject : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    private string character = "MainCharcter";

    public bool DragEnabled = true;



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
            transform.position = curPosition;
        }
    }

    void OnColliderEnter2d(Collider2D collider){
        //if is a character this object must not move
        if (collider.name == character)
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
