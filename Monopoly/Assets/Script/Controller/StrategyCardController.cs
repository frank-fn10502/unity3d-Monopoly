using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyCardController : MonoBehaviour
{

    public GlobalManager globalManager;
    public GameState nextGameState;


    public void attackButtonClick()
    {
        gameObject.SetActive(false);
        //event
    }
    public void diplomaticButtonClick()
    {
        gameObject.SetActive(false);
        //event
    }
}
