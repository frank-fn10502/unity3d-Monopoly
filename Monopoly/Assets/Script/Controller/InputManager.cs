using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public InputField diceNumber;
    public GameObject main;


    public void getInputNumber()
    {
        Debug.Log("dice number: " + diceNumber.text);
        main.GetComponent<WorldController>().globalManager.TotalStep = Convert.ToInt32(diceNumber.text);
        main.GetComponent<WorldController>().globalManager.CurrentPlayer.State = PlayerState.SearchPath;
        main.GetComponent<WorldController>().globalManager.GameState = GameState.PlayerMovement;
    }
}
