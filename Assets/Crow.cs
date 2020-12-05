using UnityEngine;

public class Crow : MonoBehaviour
{
    public player player;
    public Rigidbody2D rb2d;
    public float speed;
    private bool facingRight = true;

    void FixedUpdate()
    {
        rb2d.AddForce(player.transform.position - transform.position * speed);

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