using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(500 * Time.deltaTime, 0));
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-500 * Time.deltaTime, 0));
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(new Vector2(0, 500 * Time.deltaTime));
        }
    }
}
