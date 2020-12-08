using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShadowController : MonoBehaviour
{
    public int TimeToStart = 50;
    public float moveError = 0.01f;
    public player player;
    private int playerMovePointer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    
    private void FixedUpdate()
    {
        if (player.path.Count < TimeToStart)
        {
            return;
        }
        Vector3 position = GetNextPosition();

        UpdateMoveState(position);
    }

    private Vector3 GetNextPosition()
    {
        float delta = 0;
        var position = new Vector3();
        while (delta <= moveError)
        {
            position = player.path[playerMovePointer];
            delta = Vector3.Distance(position, transform.position);
            playerMovePointer++;
        }

        return position;
    }

    private void UpdateMoveState(Vector3 position)
    {
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("asd");
        }
    }
}