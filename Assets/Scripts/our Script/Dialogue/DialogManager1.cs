using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager1 : MonoBehaviour
{
    private Dialog m_closestNPCDialog;
    [SerializeField] public DialogManager m_dialogDisplayer;
    void Awake()
    {
        m_closestNPCDialog = null;
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.tag == "NPC")
        {
            Debug.Log("NPC");
            m_closestNPCDialog = collision.GetComponent<Dialog>();
        }
        else if (collision.tag == "InstantDialog")
        {
            Debug.Log("InstantDialog");
            Dialog instantDialog = collision.GetComponent<Dialog>();
            if (instantDialog != null)
            {
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


