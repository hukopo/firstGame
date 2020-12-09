using System;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Rigidbody2D rb2d;
    public Animator animator;
    public bool facingRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int maxExtraJump;
    private int extraJump;
    private bool jumpKeyPressed;
    private float moveHorizontal;

    public List<Vector3> path;

    private void Start()
    {
        extraJump = maxExtraJump;
    }

    void Update()
    {
        if (path.Count < GameState.TimeToStart)
        {
            moveHorizontal = 0.1f*speed;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        moveHorizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        path.Add(transform.position);
        UpdateMoveX(moveHorizontal);
        UpdateJumpState(jumpKeyPressed);
        if (jumpKeyPressed)
        {
            jumpKeyPressed = false;
        }
    }

    protected void UpdateMoveX(float moveHorizontal)
    {
        if (Math.Abs(moveHorizontal) == 0)
        {
            animator.SetBool("isRun", false);
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Math.Abs(moveHorizontal) > 0)
        {
            rb2d.velocity = new Vector2((speed * moveHorizontal), rb2d.velocity.y);
            animator.SetBool("isRun", true);
        }

        if ((!facingRight && moveHorizontal > 0) || (facingRight && moveHorizontal < 0))
        {
            Flip();
        }
    }

    protected void UpdateJumpState(bool jumpKeyPressed)
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded && rb2d.velocity.y <= 0)
        {
            extraJump = maxExtraJump;
            animator.SetBool("isJump", false);
        }

        if (jumpKeyPressed && extraJump > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            extraJump--;
            animator.SetBool("isJump", true);
        }
    }

    protected void Flip()
    {
        facingRight = !facingRight;
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            GameState.EndGame();
            return;
        }

        if (collision.gameObject.tag == "LevelFinish")
        {
            GameState.LoadNextLevel();
            return;
        }
    }
}