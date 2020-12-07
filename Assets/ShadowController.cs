using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShadowController : player
{
    private const int TimeToStart = 100;
    public player player;
    private int playerMovePointer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        jumpForce = player.jumpForce;
        maxExtraJump = player.maxExtraJump;
        speed = player.speed;
        checkRadius = player.checkRadius;
        rb2d.gravityScale = player.rb2d.gravityScale;
    }
    
    private void FixedUpdate()
    {
        if (GameState.playerMovementsX.Count < TimeToStart)
        {
            return;
        }

        var moveHorizontal = GameState.playerMovementsX[playerMovePointer];
        UpdateMoveX(moveHorizontal);

        var hasJumped = GameState.playerJumps[playerMovePointer];
        UpdateJumpState(hasJumped);
        playerMovePointer++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("asd");
        }
    }
}