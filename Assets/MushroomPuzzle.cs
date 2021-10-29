using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPuzzle : MonoBehaviour
{
    public bool hasWon = false;
    List<lightmushroom> lightmushrooms = new List<lightmushroom>();
    public ligthWin ligthwin;
    public HealthPlayer healthplayer;
    void Update()
    {
        List<bool> boolList = new List<bool>();
        lightmushrooms = new List<lightmushroom>((lightmushroom[])GameObject.FindObjectsOfType(typeof(lightmushroom)));

        foreach (lightmushroom currentMushroom in lightmushrooms)
        {
            LigthSettings currentLight = currentMushroom.GetComponentInChildren<LigthSettings>();
            boolList.Add(currentLight.isOn);

        }

        bool finalBool = true;
        foreach (bool currentBool in boolList)
        {
            finalBool = finalBool && currentBool;
        }

        if (finalBool)
        {
            //Debug.Log("win");
            ligthwin.WinCondi();
            healthplayer.domage = 0;
        }
    }
}

