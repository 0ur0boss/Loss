using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LampLigth : MonoBehaviour
{
    public bool isInsideTheZone = false;
    Light2D light2D;
    private float outerRadius;
    public float newouterRadius = 50;
    void Awake()
    {
        light2D = GetComponent<Light2D>();
        outerRadius = light2D.pointLightOuterRadius;

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
        if (isInsideTheZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                light2D.pointLightOuterRadius = newouterRadius;

            }
        }
    }

    void OnEnable()
    {
        light2D.pointLightOuterRadius = outerRadius;
    }

}
