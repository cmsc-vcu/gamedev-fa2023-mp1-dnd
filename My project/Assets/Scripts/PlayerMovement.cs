using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 15f;
    private float jumpingPower = 45f;
    private bool isFacingRight = true;
    private bool jumping = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded() && !jumping)
        {
            jumping = true;
            rb.AddForce(Vector2.up * jumpingPower, ForceMode2D.Impulse);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && jumping)
        {

            rb.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        }


        Flip();
    }

    private void FixedUpdate()
    {
        float HtargetSpeed = horizontal * speed;
        float HspeedDiff = HtargetSpeed - rb.velocity.x;
        float HaccelRate = (Mathf.Abs(HtargetSpeed) > 0.01f) ? 2 : 2;

        // Mathf.Sign(speedDiff) Preserves Movement speed
        float Hmovement = Mathf.Pow(Mathf.Abs(HspeedDiff) * HaccelRate, 2) * Mathf.Sign(HspeedDiff);

        // Apply Force
        rb.AddForce(Hmovement * Vector2.right);
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {
            jumping = false;
            return true;
        }
        return false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
