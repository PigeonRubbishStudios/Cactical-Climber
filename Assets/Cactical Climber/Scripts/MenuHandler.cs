using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MenuHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public Button[] buttons;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Top Button")
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
            }
        }

        if (e.target.tag == "Bottom Button")
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
            }
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Top Button")
        {
            Debug.Log("Button was entered");
            buttons[0].Select();
        }

        if (e.target.tag == "Bottom Button")
        {
            Debug.Log("Button was entered");
            buttons[1].Select();
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Top Button")
        {
            Debug.Log("Button was exited");
            EventSystem.current.SetSelectedGameObject(null);
        }

        if (e.target.tag == "Bottom Button")
        {
            Debug.Log("Button was exited");
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}