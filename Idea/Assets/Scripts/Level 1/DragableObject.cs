using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]
public class DragableObject : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject hand;

    private string character = "Player";
    public bool DragEnabled = true;

    public bool EnableX = true;
    public bool EnableY = true;
    public float MinPoxY = -400;
    public float MinPoxX = -400;
    public float MaxPosY = 400;
    public float MaxPosX = 400;


    void OnMouseDown()
    {
        
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {

        
        if (DragEnabled)
        {
            hand.SetActive(false);
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            //check max and mins
            float x, y, z;
            x = Mathf.Min(EnableX?curPosition.x:transform.position.x,MaxPosX);
            x = Mathf.Max(x,MinPoxX);
            y = Mathf.Min( EnableY? curPosition.y:transform.position.y,MaxPosY);
            y =  Mathf.Max(y, MinPoxY);
            transform.position = new Vector3(x,y, curPosition.z);
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
