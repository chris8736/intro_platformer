using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    private bool jump;
	private bool jump2;
	private bool shift = false;
    private int lastDirection = 1; //-1 is left, 1 is right
	private float lastVelocity;
	private bool jumpReleased = false;
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// Prevents jumping after falling off a ledge
		if (rb.velocity[1]<(0))
		{
			jump=true;
			jumpReleased=true;
		}
		
		// Handles moving left and right. Also handles friction.
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(new Vector2(1000 * Time.deltaTime, 0));
            lastDirection = 1;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(new Vector2(-1000 * Time.deltaTime, 0));
            lastDirection = -1;
        }
		else if ((rb.velocity[1]==0))
		{
			rb.velocity = new Vector2(rb.velocity[0]*.75f, rb.velocity[1]);
		}
		
		// Handles jumping and double jumping.
		if ((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")))
		{
			if (jump==false)
			{
				jump = true;
				rb.AddForce(new Vector2(0, 500 * Time.deltaTime), ForceMode2D.Impulse);
			}
			else if ((jumpReleased==true) && (jump2==false))
			{
				jump2 = true;
				rb.velocity = new Vector2(rb.velocity[0], 0);
				rb.AddForce(new Vector2(0, 500 * Time.deltaTime), ForceMode2D.Impulse);	
			}
		}
		if ((Input.GetKeyUp("w") || Input.GetKeyUp("up") || Input.GetKeyUp("space")))
		{
			if ((jumpReleased==false) && (jump==true))
			{
				jumpReleased=true;
			}
		}
		// Handles dashing.
		if (Input.GetKey(KeyCode.LeftShift) && (shift==false))
		{
			shift = true;
			jump = true;
			rb.velocity = new Vector2(rb.velocity[0], 0);
            float dashForce = 500 * Time.deltaTime;
            rb.AddForce(new Vector2(lastDirection * dashForce, dashForce), ForceMode2D.Impulse);
		}
		// If you jump while hugging a wall, the player won't calibrate. This fixes that problem.
		if ((rb.velocity[1]==0))
		{
			jump = false;
			jump2 = false;
			shift = false;
			jumpReleased = false;
			
		}
		
		if (((Mathf.Abs(rb.velocity[0]))>7.5f) && ((Input.GetKey(KeyCode.LeftShift))==false))
		{
			Debug.Log(Input.GetKey(KeyCode.LeftShift));
			rb.velocity = new Vector2(7.5f*Mathf.Sign(rb.velocity[0]), rb.velocity[1]);
		}
		Debug.Log(rb.velocity);
    }
	
	// Calibrates the player after landing on the ground.
    void OnCollisionEnter2D()
    {
			jump = false;
			jump2 = false;
			shift = false;
			jumpReleased = false;
    }
}

/*
TO-DO:
*Wall-jumping
*Satisfying dash (Ala Wolf's side-B from Super Smash Brothers)
*Fixing bugs
*Tweaking physics.

IDEAS:
*So, there's this bug where if you dash, 
then land on the ground and press jump at the same time,
you both jump and double jump at the same time.
At first, I wanted to get rid of this bug,
but now I kinda like it. 
Considering making it part of the game.
EDIT: I changed the dash from using position to using velocity and now I don't think this works anymore. Bummer.

*When I was playing around with jumping around, since there was the issue of touching the bottom of walls to regain jumps.
I instinctually started to play a "The Floor is Lava"-esque game in the testing area. Maybe a possible game
could be a Super Meat Boy-esque game where you can't touch the floor, getting through a stage with wall-jumps alone.

BUGS:
* The game still doesn't understand that touching a wall isn't the same as landing on the ground. 
It doesn't seem to count hitting a wall as a collision unless the collision happened in the air.
I think this bug is also the reason hitting the side of a wall gives you a double jump back, but not a regular jump as far as I can tell.

* Sometimes, when moving, the character will suddenly be unable to move in one direction until moved in the opposite direction.
I don't think this has to do with the friction function above, since I tried removing it and it still happened.

* You can infinitely slide by a tile and the game will somehow think you are both standing on it, letting you jump,
and not standing on it, letting you slide past it. Very bizarre. 

* The game doesn't understand that you shouldn't have your friction reduced when dashing.
*/