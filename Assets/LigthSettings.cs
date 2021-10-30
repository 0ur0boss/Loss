using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LigthSettings : MonoBehaviour
{
    public bool isInsideTheZone = false;
    Light2D light2D;
    private float outerRadius;
    public bool isOn;
    public float NewRadius = 500;
    void Awake()
    {
        light2D = GetComponent<Light2D>();
        outerRadius = light2D.pointLightOuterRadius;

    }
    public bool getIsOn()
    {
        return isOn;
    }
    public void SwitchLightOn()
    {
        if (isOn == false)
        {
            light2D.pointLightOuterRadius = NewRadius;
            isOn = true;
        } 
        else if (isOn == true)
        {
            light2D.pointLightOuterRadius = 0;
            isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        light2D.pointLightOuterRadius = outerRadius;
    }

}