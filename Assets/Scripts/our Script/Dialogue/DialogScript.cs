using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    public static bool gameIsPaused = false;

    private Dialog m_closestNPCDialog;
    [SerializeField] public DialogManager m_dialogDisplayer;
    void Awake()
    {
        m_closestNPCDialog = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            m_closestNPCDialog = collision.GetComponent<Dialog>();
        }
        else if (collision.tag == "InstantDialog")
        {

            Dialog instantDialog = collision.GetComponent<Dialog>();
            if (instantDialog != null)
            {
                if (PlayerPrefs.HasKey(collision.gameObject.name))
                {
                    return;
                }
                PlayerPrefs.SetInt(collision.gameObject.name, 1);
                m_dialogDisplayer.SetDialog(instantDialog.GetDialog());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            m_closestNPCDialog = null;
        }
        else if (collision.tag == "InstantDialog")
        {
            Destroy(collision.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (m_dialogDisplayer.IsOnScreen())
        {
            Debug.Log("5");
            Time.timeScale = 0;
            gameIsPaused = true;
            return;
        }

    }

    private void Update()
    {
        if (m_dialogDisplayer.IsOnScreen())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_closestNPCDialog != null)
            {
                m_dialogDisplayer.SetDialog(m_closestNPCDialog.GetDialog());
            }
        }
    }

}






