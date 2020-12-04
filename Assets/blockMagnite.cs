using System;
using UnityEngine;

public class blockMagnite : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb2d;
    public float speed;

    void FixedUpdate()
    {
         rb2d.AddForce(player.transform.position - transform.position * speed);
    }
}