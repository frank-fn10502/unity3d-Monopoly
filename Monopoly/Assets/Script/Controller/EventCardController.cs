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

        GameState gameState = (globalManager.CurrentPlayer.Resource.civilian <= 0)? GameState.End : nextGameState;

        List<Group> removeGroup = new List<Group>();
        foreach (Group group in globalManager.GroupList)
        {
            if(group.Resource.civilian <= 0)
            {
                removeGroup.Add(group);
            }
        }
        for(int i = 0 ,j = 0 ; i < removeGroup.Count ; i++ )
        {
            if( removeGroup[i].Equals(globalManager.GroupList[j]) )
            {
                globalManager.GroupList[j] = null;
                j++;
                i = 0;
            }
        }
        int winner = 0;
        for(int i = 0 ; i < globalManager.GroupList.Length ; i++ )
        {
            if( globalManager.GroupList[i] != null )
            {
                winner++;
            }
        }

        globalManager.GameState = winner == 1 ? GameState.End : gameState;
    }
}
