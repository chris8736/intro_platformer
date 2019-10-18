using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderMovement : MonoBehaviour
{

    public Rigidbody rb;
    private bool jump;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jump) return;
        if (Input.GetKey("d"))
        {
            rb.AddForce(1000 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-1000 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            jump = true;
            rb.AddForce(new Vector3(0, 400 * Time.deltaTime, 0), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter()
    {
        jump = false;
    }
}
