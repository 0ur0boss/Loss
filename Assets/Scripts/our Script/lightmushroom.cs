using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightmushroom : MonoBehaviour
{
    [SerializeField] List<LigthSettings> lightsToSwitch;
    public bool isInsideTheZone = false;
    public bool succeed = false;

    private GameObject player;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.tag == "Player")
        {
            isInsideTheZone = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("2");
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
                Debug.Log("3");


            }
            else
            {
            }
        }
    }
}