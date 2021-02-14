using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ClimberHand : MonoBehaviour
{
    public SteamVR_Input_Sources Hand;
    public int TouchedCount;
    public bool grabbing;
    public AudioSource[] sfx;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount++;
        }
        else if (other.CompareTag("Metal"))
        {
            sfx[0].Play();
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.CompareTag("Climbable"))
    //    {
    //        TouchedCount++;
    //    }
    //}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount--;
        }
    }

    //private void OnCollisionExit(Collision other)
    //{
    //    if ()
    //    {
    //        TouchedCount--;
    //    }
    //}
}
