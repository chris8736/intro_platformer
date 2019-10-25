﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    private bool jump;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(new Vector2(1000 * Time.deltaTime, 0));
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(new Vector2(-1000 * Time.deltaTime, 0));
        }
        if ((Input.GetKey("w") || Input.GetKey("up")) && !jump)
        {
            jump = true;
            rb.AddForce(new Vector2(0, 500 * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D()
    {
        jump = false;
    }
}