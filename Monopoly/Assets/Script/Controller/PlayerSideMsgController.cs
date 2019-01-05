using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        for ( int i = 0 ; i < groups.Length ; i++ )
        {
            playerMsg[i].transform.Find("AbilityText/Lead").gameObject.GetComponent<Text>().text = groups[i].Attributes.leadership.ToString();
            playerMsg[i].transform.Find("AbilityText/Diplomatic").gameObject.GetComponent<Text>().text = groups[i].Attributes.diplomatic.ToString();
            playerMsg[i].transform.Find("AbilityText/Peace").gameObject.GetComponent<Text>().text = groups[i].Attributes.peace.ToString();

            playerMsg[i].transform.Find("Resource/Army/ArmyText").gameObject.GetComponent<Text>().text = groups[i].Resource.army.ToString();
            playerMsg[i].transform.Find("Resource/Civilian/CivilianText").gameObject.GetComponent<Text>().text = groups[i].Resource.civilian.ToString();
            playerMsg[i].transform.Find("Resource/Antidote/AntidoteText").gameObject.GetComponent<Text>().text = groups[i].Resource.antidote.ToString();
            playerMsg[i].transform.Find("Resource/Mineral/MineralText").gameObject.GetComponent<Text>().text = groups[i].Resource.mineral.ToString();
        }
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
