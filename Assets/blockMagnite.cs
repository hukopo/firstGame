using System;
using UnityEngine;

public class blockMagnite : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb2d;
    public float speed;
    public int count;

    void FixedUpdate()
    {
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(1, 0);
        count++;
        Console.WriteLine(count);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(player.transform.position - transform.position * speed);
    }
}