using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healtBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
    public void SetHealth(int health)
    {   if(slider.value >= 0 && slider.value <= 100)
        {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
        }
        Debug.Log(slider.value);
    }
}
