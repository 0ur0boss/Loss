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
    public string name;
    public Color color;
    

    public int firstChoice;
    public int secondChoice;
    public float OuterRadius;
}

// This class is used to correctly display a full dialog
public class DialogManager : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public Text m_renderText;
    public Text m_renderName;
    public List<DialogPage> m_dialogToDisplay;

    public int pageIndex = 0;

    public ligthWin ligthwin;
    public HealthPlayer healthplayer;

    void Awake()
    {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd)
    {
        pageIndex = 0;
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
                m_renderText.text = "";
            }

            if (m_renderName != null)
            {
                m_renderName.text = "";
            }

            this.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (m_renderText == null)
        {
            this.gameObject.SetActive(false);
        }

        if (m_renderName == null)
        {
            this.gameObject.SetActive(false);
        }

        // Displays the current page
        //if (m_dialogToDisplay.Count > 0)
        if (m_dialogToDisplay[pageIndex].text != "#")
        {
            m_renderText.text = m_dialogToDisplay[pageIndex].text;
           
        }
        if (m_dialogToDisplay[pageIndex].text != "#")
        {
            m_renderName.text = m_dialogToDisplay[pageIndex].name;

        }
        else
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            ligthwin.WinCondi();
            healthplayer.domage = 0;
            gameIsPaused = false;


        }

        // Removes the page when the player presses "e"
        if (Input.GetKeyDown(KeyCode.E))
        {
            pageIndex += m_dialogToDisplay[pageIndex].secondChoice;
           // m_dialogToDisplay.RemoveAt(0);
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            pageIndex += m_dialogToDisplay[pageIndex].firstChoice;
            // m_dialogToDisplay.RemoveAt(0);

        }
    }

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
}
}
