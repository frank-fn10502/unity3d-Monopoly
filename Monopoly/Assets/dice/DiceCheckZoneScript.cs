using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCheckZoneScript : MonoBehaviour
{
    public GlobalManager globalManager;
    public GameObject diceDisplayPanel;
    public bool canRolling;
    public bool rolling;
    public int number;
    

    //public PlayerState nextPlayerState;

    Vector3 dice1Velocity;
    //Vector3 dice2Velocity;
    //Vector3 dice3Velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        dice1Velocity = Dice1Script.dice1Velocity;
        //dice2Velocity = Dice2Script.dice2Velocity;
        //dice3Velocity = Dice3Script.dice3Velocity;
    }
    void Update()
    {
        if ( globalManager.GameState == GameState.PlayerMovement &&
             canRolling &&
             Input.GetKeyDown(KeyCode.Space) )
        {
            rolling = true;
            canRolling = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if ( rolling )
        {
            if ( dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f )
            {
                switch ( col.gameObject.name )
                {
                    case "Dice1Side1":
                        number = 1;
                        break;
                    case "Dice1Side2":
                        number = 4;
                        break;
                    case "Dice1Side3":
                        number = 2;
                        break;
                    case "Dice1Side4":
                        number = 5;
                        break;
                    case "Dice1Side5":
                        number = 3;
                        break;
                    case "Dice1Side6":
                        number = 6;
                        break;
                }

                Text text =   diceDisplayPanel.transform.Find("DicePoint").GetComponent<Text>();
                text.text = number.ToString();
                rolling = false;
                diceDisplayPanel.SetActive(false);
                globalManager.CurrentPlayer.State = PlayerState.SearchPath;//?
            }
        }
        //if ( dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f )
        //{
        //    switch ( col.gameObject.name )
        //    {
        //        case "Dice2Side1":
        //            DiceNumberTextScript.dice2Number = 1;
        //            break;
        //        case "Dice2Side2":
        //            DiceNumberTextScript.dice2Number = 4;
        //            break;
        //        case "Dice2Side3":
        //            DiceNumberTextScript.dice2Number = 2;
        //            break;
        //        case "Dice2Side4":
        //            DiceNumberTextScript.dice2Number = 5;
        //            break;
        //        case "Dice2Side5":
        //            DiceNumberTextScript.dice2Number = 3;
        //            break;
        //        case "Dice2Side6":
        //            DiceNumberTextScript.dice2Number = 6;
        //            break;
        //    }
        //}
        //if ( dice3Velocity.x == 0f && dice3Velocity.y == 0f && dice3Velocity.z == 0f )
        //{
        //    switch ( col.gameObject.name )
        //    {
        //        case "Dice3Side1":
        //            DiceNumberTextScript.dice3Number = 1;
        //            break;
        //        case "Dice3Side2":
        //            DiceNumberTextScript.dice3Number = 4;
        //            break;
        //        case "Dice3Side3":
        //            DiceNumberTextScript.dice3Number = 2;
        //            break;
        //        case "Dice3Side4":
        //            DiceNumberTextScript.dice3Number = 5;
        //            break;
        //        case "Dice3Side5":
        //            DiceNumberTextScript.dice3Number = 3;
        //            break;
        //        case "Dice3Side6":
        //            DiceNumberTextScript.dice3Number = 6;
        //            break;
        //    }
        //}
        //}
    }
}
