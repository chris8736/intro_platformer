using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    private bool jump;
	private bool jump2;
	private bool shift = false;
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Debug.Log(shift);
		if (rb.velocity[1]<(0))
		{
			jump=true;
		}
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(new Vector2(1000 * Time.deltaTime, 0));
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(new Vector2(-1000 * Time.deltaTime, 0));
        }
		if (Input.GetKey(KeyCode.LeftShift) && (shift==false))
		{
			Debug.Log("Dashed");
			rb.transform.Translate(200.0f * Time.deltaTime, 100.0f * Time.deltaTime, 0);
			shift = true;
			
		}
		if ((Input.GetKey("w") || Input.GetKey("up")))
		{
			if (jump==false)
			{
				jump = true;
				rb.AddForce(new Vector2(0, 500 * Time.deltaTime), ForceMode2D.Impulse);
			}
			else
			{
				if ((jump2==false)&& (rb.velocity[1]< 0))
				{
					jump2 = true;
					
					rb.AddForce(new Vector2(0, 750 * Time.deltaTime), ForceMode2D.Impulse);	
				}
			}
		}
    }
	
    void OnCollisionEnter2D()
    {
		
        jump = false;
		jump2 = false;
		shift = false;
    }
}