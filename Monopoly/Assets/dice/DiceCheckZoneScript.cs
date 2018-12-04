using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{

	Vector3 dice1Velocity;
    Vector3 dice2Velocity;
    Vector3 dice3Velocity;
    // Update is called once per frame
    void FixedUpdate ()
    {
		dice1Velocity = Dice1Script.dice1Velocity;
        dice2Velocity = Dice2Script.dice2Velocity;
        dice3Velocity = Dice3Script.dice3Velocity;
    }

	void OnTriggerStay(Collider col)
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
if (dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f)
		{
            switch (col.gameObject.name)
            {
			    case "Dice1Side1":
				        DiceNumberTextScript.dice1Number = 1;
				        break;
			    case "Dice1Side2":
				        DiceNumberTextScript.dice1Number = 4;
				        break;
			    case "Dice1Side3":
                        DiceNumberTextScript.dice1Number = 2;
				        break;
			    case "Dice1Side4":
				        DiceNumberTextScript.dice1Number = 5;
				        break;
			    case "Dice1Side5":
				        DiceNumberTextScript.dice1Number = 3;
				        break;
			    case "Dice1Side6":
				        DiceNumberTextScript.dice1Number = 6;
				        break;
			}
            
		}
        
        if (dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Dice2Side1":
                    DiceNumberTextScript.dice2Number = 1;
                    break;
                case "Dice2Side2":
                    DiceNumberTextScript.dice2Number = 4;
                    break;
                case "Dice2Side3":
                    DiceNumberTextScript.dice2Number = 2;
                    break;
                case "Dice2Side4":
                    DiceNumberTextScript.dice2Number = 5;
                    break;
                case "Dice2Side5":
                    DiceNumberTextScript.dice2Number = 3;
                    break;
                case "Dice2Side6":
                    DiceNumberTextScript.dice2Number = 6;
                    break;
            }
        }

        if (dice3Velocity.x == 0f && dice3Velocity.y == 0f && dice3Velocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Dice3Side1":
                    DiceNumberTextScript.dice3Number = 1;
                    break;
                case "Dice3Side2":
                    DiceNumberTextScript.dice3Number = 4;
                    break;
                case "Dice3Side3":
                    DiceNumberTextScript.dice3Number = 2;
                    break;
                case "Dice3Side4":
                    DiceNumberTextScript.dice3Number = 5;
                    break;
                case "Dice3Side5":
                    DiceNumberTextScript.dice3Number = 3;
                    break;
                case "Dice3Side6":
                    DiceNumberTextScript.dice3Number = 6;
                    break;
            }
        }
        }
       
    }
}
