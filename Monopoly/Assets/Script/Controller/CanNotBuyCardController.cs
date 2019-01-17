using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanNotBuyCardController : MonoBehaviour
{
    public GlobalManager globalManager;
    public GameState nextGameState;
    public GameObject buildingArea;

    public void checkoutButtonClick()
    {
        buildingArea.SetActive(false);
        gameObject.SetActive(false);

        globalManager.GameState = nextGameState;
    }
}
