using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightmushroom : MonoBehaviour
{

    [SerializeField] List<LampLigth> lightsToSwitch;
    public bool isInsideTheZone = false;
    public bool succeed = false;

    void Start()
    {
        foreach (LampLigth currentLight in lightsToSwitch)
        {


        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isInsideTheZone = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player") //taguer player au préalable 
        {
            isInsideTheZone = false;
        }
    }

    void Update()
    {
        if (isInsideTheZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {


            }
            else
            {
            }
        }
    }
}