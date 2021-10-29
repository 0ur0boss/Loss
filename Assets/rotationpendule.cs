using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationpendule : MonoBehaviour
{
    public float RotationSpeed;
    public float Z;
    public float minZ;
    public float maxZ;
    public bool sensHoraire = false;


    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Z);
    }

    // Update is called once per frame
    void Update()
    {


        if (sensHoraire == false)

        {
            if (Z < maxZ)
            {
                Z += RotationSpeed;
                transform.rotation = Quaternion.Euler(0, 0, Z);
            }
            if (Z >= maxZ)
            {
                sensHoraire = true;
            }
        }

        if (sensHoraire == true)

        {
            if (Z > minZ)
            {
                Z -= RotationSpeed;
                transform.rotation = Quaternion.Euler(0, 0, Z);
            }
            if (Z <= minZ)
            {
                sensHoraire = false;
            }
        }

    }

}
