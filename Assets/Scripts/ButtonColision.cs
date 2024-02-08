using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Rendering;
using System;

public class ButtonColision : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] OnScreenStick sr;
    // Start is called before the first frame update
    Vector2 startPos;
    Vector2 endPos;
    void Start()
    {

    }
    private void Update()
    {

    }


    public void OnPointerDown(PointerEventData pointer)
    {

        startPos = this.transform.position;

    }
    public void OnPointerUp(PointerEventData pointer)
    {
        //mouseUp = Camera.main.ScreenToWorldPoint(pointer.position); ;
        endPos = pointer.position;
        //Debug.Log(GetAngle());
        CheckDir(GetAngle());
    }
    float GetAngle()
    {
        Vector2 dir = endPos - startPos;
        return ((float)Mathf.Atan2(dir.x, dir.y)) * 180 / Mathf.PI;
    }
    void CheckDir(float angle)
    {
        Debug.Log(angle);
        if (angle <= -20 && angle >= -40)
        {
            Debug.Log("Down");
        }
        else if (angle <= -41 && angle >= -81)
        {
            Debug.Log("DownRight");
        }
        else if (angle <= -82 && angle >= -120)
        {
            Debug.Log("Right");
        }
        else if (angle <= -121 && angle >= -161)
        {
            Debug.Log("UpRight");
        }
        else if (angle <= -161 || angle >= 160)
        {
            Debug.Log("Up");
        }
        else if (angle >= 20 && angle <= 81)
        {
            Debug.Log("DownLeft");
        }
        else if (angle >= 82 && angle <= 120)
        {
            Debug.Log("Left");
        }
        else if (angle >= 120 && angle <= 160)
        {
            Debug.Log("UpLeft");
        }
        else Debug.Log(angle);


    }

    /*
     * between 0:-20 down
     * -20-45 downLeft
     * -45-65 Left
     * -65-100 UPleft
     */
}
