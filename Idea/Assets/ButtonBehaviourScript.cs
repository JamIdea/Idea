using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonBehaviourScript : MonoBehaviour
{

    public List<GameObject> Peaks;
    public List<int> Position;
    public List<bool> Direction;
    public GameObject Manager;
    protected ScenarioBehaviourScript _managerScript;
    protected bool _animating;
    // Use this for initialization
    void Start()
    {
        _managerScript = Manager.GetComponent<ScenarioBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null)
            {
                ButtonDown();
            }
        }
        if (_animating && _managerScript.IsMoving)
        {
            AnimatePeaks();
        }
    }

    void OnMouseDown()
    {
        if (!_managerScript.IsMoving)
            ButtonDown();
    }

    void ButtonDown()
    {
        _managerScript.IsMoving = true;
        _animating = true;
        Debug.Log("Touched it");
    }

    void AnimatePeaks()
    {
        bool animateSomething = false;
        for (int i = 0; i < Position.Count; i++)
        {
            var tmpPosition = Peaks[Position[i]].transform.localPosition;
            if ((tmpPosition.y >= _managerScript.MaxPosition && Direction[i]) || (tmpPosition.y <= _managerScript.MinPosition && !Direction[i]))
            {
                _animating = _managerScript.IsMoving = false;
            }
            else
            {
                animateSomething = true;
                if (Direction[i])
                    tmpPosition.y += _managerScript.Step;
                else
                    tmpPosition.y -= _managerScript.Step;
                Peaks[Position[i]].transform.localPosition = tmpPosition;
            }

        }
        if (animateSomething)
            _animating = _managerScript.IsMoving = true;
    }
}
