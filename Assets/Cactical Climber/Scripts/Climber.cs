using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class Climber : MonoBehaviour
{
    public ClimberHand LeftHand;
    public ClimberHand RightHand;
    public SteamVR_Action_Boolean ToggleGripButton;
    public SteamVR_Action_Pose position;
    public ConfigurableJoint ClimberHandle;
    public AudioSource[] sfx;

    public bool Climbing;
    private ClimberHand ActiveHand;
    public bool ableToClimb;

    void Start()
    {
        ableToClimb = true;
    }

    void Update()
    {
        
        if (ableToClimb)
        {
            updateHand(RightHand);
            updateHand(LeftHand);
        }
        else if (!ableToClimb)
        {
            ClimberHandle.connectedBody = null;
            Climbing = false;

            GetComponent<Rigidbody>().useGravity = true;
        }

        if(Climbing)
        {
            ClimberHandle.targetPosition = - ActiveHand.transform.localPosition;
        }
    }

    void updateHand(ClimberHand Hand)
    {
        if (Climbing && Hand == ActiveHand)
        {
            if (ToggleGripButton.GetStateUp(Hand.Hand))
            {
                ClimberHandle.connectedBody = null;
                Climbing = false;

                GetComponent<Rigidbody>().useGravity = true;
            }
        }
        else
        {
            if (ToggleGripButton.GetStateDown(Hand.Hand) || Hand.grabbing)
            {
                Hand.grabbing = true;
                if (Hand.TouchedCount > 0)
                {
                    ActiveHand = Hand;
                    Climbing = true;
                    ClimberHandle.transform.position = Hand.transform.position;
                    GetComponent<Rigidbody>().useGravity = false;
                    ClimberHandle.connectedBody = GetComponent<Rigidbody>();
                    Hand.grabbing = false;
                    sfx[0].Play();
                }
            }
        }
    }
}
