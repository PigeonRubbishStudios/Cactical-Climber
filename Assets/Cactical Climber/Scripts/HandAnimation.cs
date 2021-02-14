using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandAnimation : MonoBehaviour
{
    public SteamVR_Input_Sources hand;
    public Animator anim;

    public AudioSource[] sfx;
    
    void Update()
    {
        if (SteamVR_Actions._default.ClimbGrip.GetStateDown(hand))
        {
            anim.SetBool("Extended", true);
            sfx[0].Play();
        }
        else if (SteamVR_Actions._default.ClimbGrip.GetStateUp(hand))
        {
            anim.SetBool("Extended", false);
            sfx[1].Play();
        }
    }
}
