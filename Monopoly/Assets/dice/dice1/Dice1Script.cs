using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice1Script : MonoBehaviour
{

	static Rigidbody rb;
	public static Vector3 dice1Velocity;

	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		dice1Velocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space))
        {
			DiceNumberTextScript.dice1Number = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			//transform.position = new Vector3 (0, 2, -2);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 500);
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
