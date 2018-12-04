﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice3Script : MonoBehaviour
{

	static Rigidbody rb;
	public static Vector3 dice3Velocity;

	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		dice3Velocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space))
        {
			DiceNumberTextScript.dice3Number = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			//transform.position = new Vector3 (0, 2, -2);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 1000);
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
