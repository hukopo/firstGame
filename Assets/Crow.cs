using System;
using UnityEngine;

public class Crow : MonoBehaviour
{
    private player player;
    public Rigidbody2D rb2d;
    public LayerMask whatIsGround;
    public float speed;
    private bool facingRight = true;
    private float maxY;
    private bool lastMovingLeft;

    private void Start()
    {
        maxY = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    void FixedUpdate()
    {
        var playerIsVisible = Vector2.Distance(player.transform.position, transform.position) < 6f &&
                              player.transform.position.y < maxY;
        if (playerIsVisible)
        {
            rb2d.AddForce((player.transform.position - transform.position) * speed);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
         
        if (maxY < transform.position.y)
        {
            rb2d.velocity  = new Vector2(0, -1 * speed );
        }

        if (maxY - transform.position.y > 1f)
        {
            rb2d.AddForce(Vector2.up * speed * 5);
            //rb2d.velocity  = new Vector2(0, speed * 1.3f);
        }

       

        if (player.rb2d.position.x - transform.position.x > 0 && facingRight ||
            player.rb2d.position.x - transform.position.x < 0 && !facingRight)
        {
            Flip();
        }
    }

    protected void Flip()
    {
        facingRight = !facingRight;
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}