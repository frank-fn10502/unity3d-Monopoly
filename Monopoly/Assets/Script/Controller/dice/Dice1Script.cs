using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice1Script : MonoBehaviour
{

	static Rigidbody rb;
	public static Vector3 dice1Velocity;
    private Quaternion quate;
    
    // Use this for initialization
    void Start ()
    {
		rb = GetComponent<Rigidbody> ();
        quate = Quaternion.identity;
        quate.eulerAngles = new Vector3(0 ,0 ,0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		dice1Velocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space))
        {
            gameObject.transform.position += new Vector3(0 ,2f ,0);
            gameObject.transform.rotation = quate;

            //DiceNumberTextScript.dice1Number = 0;
            float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);


			rb.AddForce (transform.up * 1000);
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
