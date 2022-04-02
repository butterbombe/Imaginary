using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVelocity;
    [SerializeField] float lowJumpMultiplier = 2.5f;
    [SerializeField] float fallMultiplier = 2f;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform bottomLeft;
    [SerializeField] Transform bottomRight;

    private Rigidbody2D rb;
    private float moveX;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        Jump();
        BetterJumping();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void BetterJumping()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        rb.velocity = (new Vector2(moveX * moveSpeed * Time.deltaTime, rb.velocity.y));
    }

    private void Jump()
    {
        if (!Input.GetButtonDown("Jump")) return;
        if (!isGrounded()) return;
        rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse); 
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapArea(bottomLeft.position, bottomRight.position, groundLayer);    
    }
}