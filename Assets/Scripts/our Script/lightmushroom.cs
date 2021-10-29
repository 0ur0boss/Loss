using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightmushroom : MonoBehaviour
{
    [SerializeField] List<LigthSettings> lightsToSwitch;
    public bool isInsideTheZone = false;
    public bool succeed;


    private GameObject player;

    void Start()
    {
        succeed = false;
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
        if (other.tag == "Player")
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
                foreach (LigthSettings currentLight in lightsToSwitch)
                {
                    currentLight.SwitchLightOn();
                }
            }
            else
            {
            }
        }
    }
}