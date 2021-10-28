using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 300;
    public float jumpForce;

    public bool isJumping;
    //public bool isGrounded;

    private Dialog m_closestNPCDialog; //
    [SerializeField]public DialogManager m_dialogDisplayer; //

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        m_closestNPCDialog = null; //
    }
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * (10 * moveSpeed) * Time.deltaTime;

       if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        if (m_dialogDisplayer.IsOnScreen())
        {
            return;
        }
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping  = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //
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

    private void OnTriggerExit2D(Collider2D collision) //
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

    private void Update() //
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
