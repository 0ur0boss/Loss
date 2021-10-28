using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationpendule : MonoBehaviour
{
    public float RotationSpeed;
    public float Z;
    public float minZ;
    public float maxZ;
    Vector3 currentAngles;
    private bool sensHoraire = false;

    // Update is called once per frame
    void Update()
    {
        if (sensHoraire == false)

        {
            while (Z<=maxZ)
            {
            if (Input.GetKeyDown(KeyCode.Z)) Z = 1 - Z;
            currentAngles += new Vector3(0,0,Z) * Time.deltaTime * RotationSpeed;
            transform.eulerAngles = currentAngles;
            }
            if (Z == maxZ)
            {
                sensHoraire = true;
            }
        }

        /*if (sensHoraire == true)

        {
            while (Z >= minZ)
            {
                if (Input.GetKeyDown(KeyCode.Z)) Z = 1 - Z;
                currentAngles += new Vector3(0, 0, Z) * Time.deltaTime * RotationSpeed;
                transform.eulerAngles = currentAngles;
            }
            if (Z == maxZ)
            {
                sensHoraire = false;
            }
        }*/
    }

}
