using UnityEngine;
using System.Collections;

public class RockBehaviourScript : MonoBehaviour
{
    public float Lifes;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null)
            {
                PunchRock();
            }
        }
       
    }

    void OnMouseDown()
    {
            PunchRock();
    }

    void PunchRock()
    {
        Lifes--;
        if (Lifes <= 0)
            Destroy(this.gameObject);
       
        Debug.Log("Touched it");
    }
}
