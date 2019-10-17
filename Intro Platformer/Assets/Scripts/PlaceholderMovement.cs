using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderMovement : MonoBehaviour
{

    public Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 500 * Time.deltaTime, 0);
        }
    }
}
