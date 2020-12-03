using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);


        if ((!facingRight && moveHorizontal > 0) || (facingRight && moveHorizontal < 0))
        {
            Flip();
        }

        UpdateJumpState();
    }
}
