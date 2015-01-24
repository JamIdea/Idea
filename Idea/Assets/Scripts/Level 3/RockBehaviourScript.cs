using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockBehaviourScript : MonoBehaviour
{
    public int Lifes;
    int maxLifes;
    public List<Sprite> States;

    // Use this for initialization
    void Start()
    {
        maxLifes = Lifes;
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
        else if (Lifes % 2 == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = States[(maxLifes - Lifes) / 2];
        }
        Debug.Log("Touched it");
    }
}
