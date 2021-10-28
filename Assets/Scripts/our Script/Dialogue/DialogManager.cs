using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This struct represents one dialog page
// (text on the current page, and its color)
[System.Serializable]
public struct DialogPage
{
    public string text;
    public Color color;
}

// This class is used to correctly display a full dialog
public class DialogManager : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public Text m_renderText;
    public List<DialogPage> m_dialogToDisplay;

    void Awake()
    {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
                m_renderText.text = "";
            }

            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_renderText == null)
        {
            this.gameObject.SetActive(false);
        }

        // Displays the current page
        if (m_dialogToDisplay.Count > 0)
        {
            m_renderText.text = m_dialogToDisplay[0].text;
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        // Removes the page when the player presses "e"
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_dialogToDisplay.RemoveAt(0);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    }

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
    }
}
