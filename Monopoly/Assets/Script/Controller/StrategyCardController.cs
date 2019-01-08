using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyCardController : MonoBehaviour
{
    public GlobalManager globalManager;
    public GameState nextGameState;
    public bool detection;

    private void Awake()
    {
        detection = false;
    }
    private void Update()
    {
        if ( detection && globalManager.IsAuto )
        {
            System.Random random = new System.Random();
            int choise = (random.Next(100) + globalManager.GroupList[globalManager.CurrentGroupIndex].Attributes.diplomatic / 10);
            choise /= 50;

            if ( choise == 0 )
            {
                attackButtonClick();
            }
            else
            {
                diplomaticButtonClick();
            }
            detection = false;
        }
    }

    public void attackButtonClick()
    {
        gameObject.SetActive(false);
        EventBase eventData = globalManager.Events.doEvent(Eventtype.Attack_Plant
                                                          ,globalManager.createList()
                                                          ,globalManager.CurrentPlayer);

        globalManager.DisplayManager.displayEvent(eventData ,nextGameState);
    }
    public void diplomaticButtonClick()
    {
        gameObject.SetActive(false);
        BuildingBlock buildingBlock = (BuildingBlock)globalManager.map.BlockList[globalManager.CurrentPlayer.CurrentBlockIndex];
    
        EventBase eventData = buildingBlock.Building.cost(new List<Group>(globalManager.GroupList) ,globalManager.CurrentPlayer);
        globalManager.DisplayManager.displayEvent(eventData ,nextGameState);
    }
}
