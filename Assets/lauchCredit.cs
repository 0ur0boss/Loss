using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lauchCredit : MonoBehaviour
{
    bool loadingStarted = false;
    float secondsLeft = 0;
    void Start()
    {
        StartCoroutine(DelayLoadLevel(10));
    }
    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--secondsLeft > 0);
        SceneManager.LoadScene("Crédits");
    }
    void OnGUI()
    {
        if (loadingStarted)
            GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
    }
}
