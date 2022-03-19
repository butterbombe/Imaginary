using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVelocity;
    [SerializeField] float lowJumpMultiplier = 2.5f;
    [SerializeField] float fallMultiplier = 2f;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform bottomLeft;
    [SerializeField] Transform bottomRight;

    [Header("Eyes")]
    [SerializeField] Image blackscreen;

    Rigidbody2D rb;
    VoidHandler voidHandler;

    private float moveX;
    private bool isGrounded;


    private void Start()
    {
        blackscreen.enabled = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        voidHandler = FindObjectOfType<VoidHandler>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        Jump();
        GetInput();
        GroundCheck();
        VoidManaging();
    }

    private void VoidManaging()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            blackscreen.enabled = true;
            voidHandler.DisableVoids();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            blackscreen.enabled = false;
            voidHandler.EnableVoids();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    #region PlayerMovement
    public void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
    }
    private void Move()
    {
        transform.Translate((new Vector3(moveX, 0) * moveSpeed) * Time.deltaTime);
    }
    private void Jump()
    {
        if (!Input.GetButtonDown("Jump"))
        {
            return;
        }
        if (!isGrounded)
        {
            return;
        }
        rb.velocity = Vector2.up * jumpVelocity;
    }
    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapArea(bottomLeft.position, bottomRight.position, groundLayer);
    }
    #endregion
}
