using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool dialogDisplayed = false;
    private float Win;
    

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Win = 0;

        GameObject camera = GameObject.Find("Main Camera");
    }


    public void Winfinal()
    {
        Win = Win + 1;
        Debug.Log(Win);
        if (Win >= 4)
        {
           // videoPlayer.url = "/Assets/Video/End.mp4";          
        }
    }
}
