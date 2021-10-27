using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightmushroom : MonoBehaviour
{

    [SerializeField] List<LampLigth> lightsToSwitch;

    void Start()
    {
        foreach (LampLigth currentLight in lightsToSwitch)
        {
            //if (currentLight.getRadius() == radiusMin);

        }

    }

    



    void Update()
    {
      
    }
}