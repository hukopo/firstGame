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
        GameState.playerMovementsX.Clear();
        GameState.playerJumps.Clear();
    }

    void Update()
    {
        var jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        var moveHorizontal = Input.GetAxis("Horizontal");
        GameState.playerMovementsX.Add(moveHorizontal);
        UpdateMoveX(moveHorizontal);
        GameState.playerJumps.Add(jumpKeyPressed);
        UpdateJumpState(jumpKeyPressed);
    }

    protected void UpdateMoveX(float moveHorizontal)
    {
        if (Math.Abs(moveHorizontal) > 0)
        {
            rb2d.velocity = new Vector2((speed * moveHorizontal), rb2d.velocity.y);
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
        }

        if (jumpKeyPressed && extraJump > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            extraJump--;
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