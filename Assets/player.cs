using System;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;

    public Rigidbody2D rb2d;
    public bool facingRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int maxExtraJump;

    private int extraJump;

    private void Start()
    {
        extraJump = maxExtraJump;
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        GameState.playerMovementsX.Add(moveHorizontal);
        UpdateMoveX(moveHorizontal);
        
        var jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        GameState.playerJumps.Add(jumpKeyPressed);
        UpdateJumpState(jumpKeyPressed);
    }
    protected void UpdateMoveX(float moveHorizontal)
    {
        var movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

        if ((!facingRight && moveHorizontal > 0) || (facingRight && moveHorizontal < 0))
        {
            Flip();
        }
    }

    protected void UpdateJumpState(bool jumpKeyPressed)
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            extraJump = maxExtraJump;
        }
        
        if (jumpKeyPressed && extraJump > 0)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (jumpKeyPressed && extraJump == 0 && isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpForce;
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
        }
    }
}