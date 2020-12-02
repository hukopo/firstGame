using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Rigidbody2D rb2d;

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
        if (moveVertical > 0)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}