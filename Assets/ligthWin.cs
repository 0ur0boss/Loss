using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class ligthWin : MonoBehaviour
{
    Light2D light2D;
    private float outerRadius;
    private float outerAngles;
    public float NewRadius = 50;
    public float NewAngles = 360;
    bool WinEnigme = false;
    void Awake()
    {
        light2D = GetComponent<Light2D>();
        outerRadius = light2D.pointLightOuterRadius;
        outerAngles = light2D.pointLightOuterAngle;
    }
    void OnEnable()
    {
        light2D.pointLightOuterRadius = outerRadius;
        light2D.pointLightOuterAngle = outerAngles;
    }


    public void WinCondi()
    {
        light2D.pointLightOuterRadius = NewRadius;
        light2D.pointLightOuterAngle = NewAngles;
        if (WinEnigme == false)
        {
            WinEnigme = true;
            GameManager.instance.Winfinal();
        }
    }
}
