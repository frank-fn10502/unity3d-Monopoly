using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardController : MonoBehaviour
{
    public GlobalManager globalManager;
    public GameState nextGameState;
    public bool detection;

    private void Update()
    {
        if(detection && globalManager.IsAuto)
        {
            eventButtonClick();
            detection = false;
        }
    }
    public void eventButtonClick()
    {
        gameObject.SetActive(false);
        calWhoDead(nextGameState);
    }

    private void calWhoDead(GameState nextGameState)
    {
        GameState gameState = (globalManager.CurrentPlayer.Resource.civilian <= 0)? GameState.End : nextGameState;

        List<Group> removeGroup = new List<Group>();
        foreach ( Group group in globalManager.GroupList )
        {
            if ( group != null && group.Resource.civilian <= 0 )
            {
                removeGroup.Add(group);
            }
        }
        for ( int i = 0 ; i < removeGroup.Count ; i++ )
        {
            for ( int j = 0 ; j < globalManager.GroupList.Length ; j++ )
            {
                if ( removeGroup[i].Equals(globalManager.GroupList[j]) )
                {
                    globalManager.GroupList[j] = null;
                    break;
                }
            }
        }

        int winner = 0;
        for ( int i = 0 ; i < globalManager.GroupList.Length ; i++ )
        {
            if ( globalManager.GroupList[i] != null )
            {
                winner++;
            }
        }

        globalManager.GameState = winner == 1 ? GameState.End : gameState;
    }
}
