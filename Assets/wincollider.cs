using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wincollider : MonoBehaviour
{
    private GameObject player;
    public ligthWin ligthwin;
    public HealthPlayer healthplayer;
    public bool isInsideTheZone = false;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (isInsideTheZone)
        {

            ligthwin.WinCondi();
            healthplayer.domage = 0;

        }

    }
}
