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
        Debug.Log("11");
        if (collision.tag == "NPC")
        {
            Debug.Log("10");
            m_closestNPCDialog = collision.GetComponent<Dialog>();
        }
        else if (collision.tag == "InstantDialog")
        {
            Debug.Log("9");

            Dialog instantDialog = collision.GetComponent<Dialog>();
            if (instantDialog != null)
            {
                Debug.Log("8");
                m_dialogDisplayer.SetDialog(instantDialog.GetDialog());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            Debug.Log("7");
            //Time.timeScale = 1;
            //gameIsPaused = false;
            m_closestNPCDialog = null;
        }
        else if (collision.tag == "InstantDialog")
        {
            Debug.Log("6");
            Destroy(collision.gameObject);
        }
    }
    private void FixedUpdate()
    {
        Debug.Log("4");
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
            Debug.Log("1");
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("2");
            if (m_closestNPCDialog != null)
            {
                Debug.Log("3");
                m_dialogDisplayer.SetDialog(m_closestNPCDialog.GetDialog());
            }
        }
    }

}






