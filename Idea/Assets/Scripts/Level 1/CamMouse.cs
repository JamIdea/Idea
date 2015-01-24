using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse")]
public class CamMouse : MonoBehaviour
{
   
    float speed = 30;
    Vector3 center;

    void Start(){
        center = new Vector2(Screen.width / 2, Screen.height / 2);        
    }
    void Update()
    {
        Vector3 mpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0.0f) - center;
        Vector3 vel = mpos.normalized * speed;
        transform.position += vel * Time.deltaTime;
        
    }
}
