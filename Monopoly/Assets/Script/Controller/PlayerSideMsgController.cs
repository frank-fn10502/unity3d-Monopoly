using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMsgController : MonoBehaviour
{
    public GlobalManager globalManager;
    private GameObject kingMsg;
    private List<GameObject> playerMsg;

    private void Awake()
    {
        setPlayerGameObj();
    }
    public void showButtonClick()
    {
        gameObject.SetActive(true);
    }
    public void hideButtonClick()
    {
        gameObject.SetActive(false);
    }
    public void displayPlayerList(Group[] groups)
    {

    }


    /*==========設定==========*/
    private void setPlayerGameObj()
    {
        kingMsg = GameObject.Find("KingMsg");
        playerMsg = new List<GameObject>();
        for ( int i = 0 ; i < Constants.PLAYERNUMBER ; i++ )
        {
            playerMsg.Add(GameObject.Find("Player" + ( i + 1 ) + "Msg"));
        }
    }
}
