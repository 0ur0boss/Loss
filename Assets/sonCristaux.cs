using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[SerializeField]


public class sonCristaux : MonoBehaviour
{
    public AudioSource audio1;
    public bool isInsideTheZone = false;
     
    void Start()
    {
       // gameObject.tag = "Player";
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
 
        if (other.tag == "Player") //taguer player et cristal au préalable 
        {

            isInsideTheZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player") //taguer player et cristal au préalable 
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
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                //PlayOneShot(son1);
                Debug.Log("jesaispas2");
            }
            else
            {
            }
        }
    }
}
