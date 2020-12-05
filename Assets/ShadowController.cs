using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : player
{
    private const int TimeToStart = 100;
    public player player;
    private int playerMovePointer = 0;
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = player.jumpForce;
        maxExtraJump = player.maxExtraJump;
        speed = player.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
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
