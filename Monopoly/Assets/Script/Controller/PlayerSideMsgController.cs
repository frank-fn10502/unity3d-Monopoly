using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSideMsgController : MonoBehaviour
{
    public GlobalManager globalManager;
    private GameObject kingMsg;
    private List<GameObject> playerMsg;
    private GameObject nowPlayerInfo;

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
        for ( int i = 0 ; i < groups.Length - 1 ; i++ )
        {            
            setPlayerInfo(playerMsg[i] ,groups[i]);
        }
        setPlayerInfo(kingMsg ,groups[groups.Length- 1]);
    }


    /*==========設定==========*/
    private void setPlayerGameObj()
    {
        nowPlayerInfo = GameObject.Find("NowPlayerInfo");
        kingMsg = GameObject.Find("KingMsg");
        playerMsg = new List<GameObject>();
        for ( int i = 0 ; i < Constants.PLAYERNUMBER ; i++ )
        {
            playerMsg.Add(GameObject.Find("Player" + ( i + 1 ) + "Msg"));
        }
    }
    private void setPlayerInfo(GameObject obj ,Group group)
    {
        obj.transform.Find("AbilityText/Lead").gameObject.GetComponent<Text>().text = group.Attributes.leadership.ToString();
        obj.transform.Find("AbilityText/Diplomatic").gameObject.GetComponent<Text>().text = group.Attributes.diplomatic.ToString();
        obj.transform.Find("AbilityText/Peace").gameObject.GetComponent<Text>().text = group.Attributes.peace.ToString();

        obj.transform.Find("Resource/Army/ArmyText").gameObject.GetComponent<Text>().text = group.Resource.army.ToString();
        obj.transform.Find("Resource/Civilian/CivilianText").gameObject.GetComponent<Text>().text = group.Resource.civilian.ToString();
        obj.transform.Find("Resource/Antidote/AntidoteText").gameObject.GetComponent<Text>().text = group.Resource.antidote.ToString();
        obj.transform.Find("Resource/Mineral/MineralText").gameObject.GetComponent<Text>().text = group.Resource.mineral.ToString();

        obj.transform.Find("Block").gameObject.GetComponent<Text>().text = string.Format("{0:000}",group.Resource.blockList.Count);
        obj.transform.Find("Team").gameObject.GetComponent<Image>().color = group.materialBall.color;

        if (globalManager.CurrentPlayer.Equals(group))
        {           
            nowPlayerInfo.transform.Find("NowPlayer").gameObject.GetComponent<Text>().text = group.name;
            nowPlayerInfo.transform.Find("Army").gameObject.GetComponent<Text>().text = group.Resource.army.ToString();
            nowPlayerInfo.transform.Find("Civilian").gameObject.GetComponent<Text>().text = group.Resource.civilian.ToString();
            nowPlayerInfo.transform.Find("Antidote").gameObject.GetComponent<Text>().text = group.Resource.antidote.ToString();
            nowPlayerInfo.transform.Find("Mineral").gameObject.GetComponent<Text>().text = group.Resource.mineral.ToString();

            obj.transform.Find("Round").gameObject.SetActive(true);
        }
        else
        {
            obj.transform.Find("Round").gameObject.SetActive(false);
        }
    }
}
