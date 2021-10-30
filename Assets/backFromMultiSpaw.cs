using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backFromMultiSpaw : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {


        if (PlayerPrefs.HasKey("BACKX"))
        {
            player.transform.position = new Vector3( (PlayerPrefs.GetFloat("BACKX")), (PlayerPrefs.GetFloat("BACKY")), (PlayerPrefs.GetFloat("BACKZ")) );
        };

        if (PlayerPrefs.HasKey("BACKY"))
        {
            player.transform.position = new Vector3((PlayerPrefs.GetFloat("BACKX")), (PlayerPrefs.GetFloat("BACKY")), (PlayerPrefs.GetFloat("BACKZ")));
        };

        if (PlayerPrefs.HasKey("BACKX"))
        {
            player.transform.position = new Vector3((PlayerPrefs.GetFloat("BACKX")), (PlayerPrefs.GetFloat("BACKY")), (PlayerPrefs.GetFloat("BACKZ")));
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
