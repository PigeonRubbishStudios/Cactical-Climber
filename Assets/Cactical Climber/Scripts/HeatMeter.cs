using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    public FrostEffect frost;
    public LevelManager levelManager;
    public Image heatMeter;
    public float emptySpeed;
    public float doubleEmptySpeed;
    public float refillSpeed;
    private float currentValueWatch;
    private float currentValueFrost;

    private bool isHot;
    private bool isCold;

    // Start is called before the first frame update
    void Start()
    {
        currentValueWatch = 100;
        currentValueFrost = 0;
        isHot = false;
        isCold = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValueWatch > 100)
        {
            currentValueWatch = 100;
        }

        if (currentValueFrost < 0)
        {
            currentValueFrost = 0;
        }

        if (!isHot && currentValueWatch <= 100)
        {
            if (!isCold)
            {
                currentValueWatch -= emptySpeed * Time.deltaTime;
            }
            else if (isCold)
            {
                currentValueWatch -= doubleEmptySpeed * Time.deltaTime;
            }
        }
        else if (isHot && currentValueWatch < 100)
        {
            currentValueWatch += refillSpeed * Time.deltaTime;
        }

        if (!isHot && currentValueFrost <= 100)
        {
            if (!isCold)
            {
                currentValueFrost += emptySpeed * Time.deltaTime;
            }
            else if (isCold)
            {
                currentValueFrost += doubleEmptySpeed * Time.deltaTime;
            }
        }
        else if (isHot && currentValueFrost < 100)
        {
            currentValueFrost -= refillSpeed * Time.deltaTime;
        }

        frost.FrostAmount = currentValueFrost / 100;
        heatMeter.fillAmount = currentValueWatch / 100;

        if (currentValueWatch <= 0 || currentValueFrost >= 100)
        {
            levelManager.LoadLose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hot"))
        {
            isHot = true;
            print("Working Hot");
        }

        if (other.CompareTag("Cold"))
        {
            isCold = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hot"))
        {
            isHot = false;
        }

        if (other.CompareTag("Cold"))
        {
            isCold = false;
        }
    }
}
