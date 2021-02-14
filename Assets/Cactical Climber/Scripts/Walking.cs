using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Walking : MonoBehaviour
{
    public Climber climberScript;

    private Vector2 trackpad;
    private float Direction;
    private Vector3 moveDirection;


    public SteamVR_Input_Sources Hand;//Set Hand To Get Input From
    public SteamVR_Action_Boolean runButton;
    public float speed;
    public GameObject Head;
    public CapsuleCollider Collider;
    public GameObject AxisHand;//Hand Controller GameObject
    public float Deadzone;//the Deadzone of the trackpad. used to prevent unwanted walking.

    void Update()
    {
        //Set size and position of the capsule collider so it maches our head.
        if (!climberScript.Climbing)
        {
            Collider.height = Head.transform.localPosition.y;
            Collider.center = new Vector3(Head.transform.localPosition.x, Head.transform.localPosition.y / 2, Head.transform.localPosition.z);
        }
        else if (climberScript.Climbing)
        {
            Collider.height = Head.transform.localPosition.y / 3;
            Collider.center = new Vector3(Head.transform.localPosition.x, Head.transform.localPosition.y, Head.transform.localPosition.z);
        }

        //get the angle of the touch and correct it for the rotation of the controller
        moveDirection = Quaternion.AngleAxis(Angle(trackpad) + AxisHand.transform.localRotation.eulerAngles.y, Vector3.up) * Vector3.forward;

        updateInput();

        if (runButton.GetStateDown(Hand))
        {
            speed = 1.25f;
        }
        else if (runButton.GetStateUp(Hand))
        {
            speed = 0.75f;
        }

        //make sure the touch isn't in the deadzone and we aren't going to fast.
        if (GetComponent<Rigidbody>().velocity.magnitude < speed && trackpad.magnitude > Deadzone)
        {
            GetComponent<Rigidbody>().AddForce(moveDirection * 30);
        }
    }
    public static float Angle(Vector2 p_vector2)
    {
        if (p_vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
        }
    }
    private void updateInput()
    {
        trackpad = SteamVR_Actions._default.MovementAxis.GetAxis(Hand);
    }
}
