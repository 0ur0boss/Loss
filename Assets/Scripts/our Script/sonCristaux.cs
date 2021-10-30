using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[SerializeField]


public class sonCristaux : MonoBehaviour
{
    public AudioSource audio1;
    public bool isInsideTheZone = false;
    public bool succeed = false;

    public int riddleId = 1;
    public GameObject player;

     
    void Start()
    {
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
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                player.GetComponent<PlayerRiddle>().AddRiddleAnswer(riddleId);

            }
            else
            {
            }
        }
    }
}
