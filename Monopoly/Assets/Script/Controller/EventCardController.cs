using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardController : MonoBehaviour
{
    public GlobalManager globalManager;
    public GameState nextGameState;


    public void eventButtonClick()
    {
        gameObject.SetActive(false);
        globalManager.GameState = nextGameState;
    }
}
