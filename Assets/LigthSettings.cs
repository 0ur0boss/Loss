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
    void Awake()
    {
        light2D = GetComponent<Light2D>();
        outerRadius = light2D.pointLightOuterRadius;

    }
    
    public bool getIsOn()
    {
        return isOn;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player") //taguer player
        {

            isInsideTheZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player") //taguer player
        {

            isInsideTheZone = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == false)
        {
            light2D.pointLightOuterRadius = 0;
        } else
        {
            light2D.pointLightOuterRadius = 10;
        }

    }

    void OnEnable()
    {
        light2D.pointLightOuterRadius = outerRadius;
    }

}