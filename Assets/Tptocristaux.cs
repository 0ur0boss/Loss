using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tptocristaux : MonoBehaviour
{

    public bool isInsideTheZone = false;

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
            SceneManager.LoadScene("TestCristaux");
        }
    }
}


