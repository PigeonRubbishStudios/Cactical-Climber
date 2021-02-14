using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class GripMeter : MonoBehaviour
{
    public Climber climber;
    public Image gripMeter;
    public float emptySpeed;
    public float refillSpeed;
    private float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (climber.Climbing && currentValue <= 100)
        {
            currentValue -= emptySpeed * Time.deltaTime;
        }
        else if (!climber.Climbing && currentValue < 100)
        {
            currentValue += refillSpeed * Time.deltaTime;
        }

        gripMeter.fillAmount = currentValue / 100;

        if (currentValue > 0)
        {
            climber.ableToClimb = true;
        }
        else
        {
            climber.ableToClimb = false;
        }

        if (currentValue > 100)
        {
            currentValue = 100;
        }

        if (currentValue < 0)
        {
            currentValue = 0;
        }
    }
}
