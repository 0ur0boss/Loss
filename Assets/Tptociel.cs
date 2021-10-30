using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tptociel : MonoBehaviour
{

    public bool isInsideTheZone = false;
    public Vector3 backSpawn;

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

    void Update()
    {
        if (isInsideTheZone)
        {
            SceneManager.LoadScene("Ciel");
            PlayerPrefs.SetFloat("BACKX", backSpawn.x);
            PlayerPrefs.SetFloat("BACKY", backSpawn.y);
            PlayerPrefs.SetFloat("BACKZ", backSpawn.z);
        }
    }
}