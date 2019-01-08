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
    private GameObject characters;
    private bool auto;

    private void Awake()
    {
        auto = true;
        setPlayerGameObj();

        characters = GameObject.Find("Character");
    }


    public void showButtonClick()
    {
        gameObject.SetActive(true);
    }
    public void hideButtonClick()
    {
        gameObject.SetActive(false);
    }

    public void displayPlayerList(Group[] groups ,List<Faction> factionList)
    {
        if ( factionList != null )
        {
            string[] fileName = new string[8];
            for ( int i = 0 ; i < fileName.Length ; i++ )
            {
                fileName[i] = string.Format("char{0}/cf{0}" ,i + 1);
            }
            fileName[7] = "boss/bossf";

            for ( int i = 0 ; i < groups.Length ; i++ )
            {
                for ( int j = 0 ; j < fileName.Length ; j++ )
                {
                    if ( groups[i].CurrentActor.FileName == fileName[j] )
                    {
                        if ( j < 7 )
                        {
                            setIntailPlayerInfo(playerMsg[i] ,groups[i] ,( j + 1 ));
                        }
                        else
                        {
                            setIntailPlayerInfo(kingMsg ,groups[i] ,8);
                        }
                        break;
                    }
                }
            }
        }
        else
        {
            for ( int i = 0 ; i < groups.Length - 1 ; i++ )
            {
                if(groups[i] != null)
                {
                    setPlayerInfo(playerMsg[i] ,groups[i]);
                }            
                else
                {

                }
            }
            if( groups[groups.Length - 1] != null)
            {
                setPlayerInfo(kingMsg ,groups[groups.Length - 1]);
            }            
        }
    }
    public void onAutoButtonClick()
    {
        globalManager.IsAuto = auto;
        auto = !auto;
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
    private void setIntailPlayerInfo(GameObject obj ,Group group ,int no)
    {
        Texture charImage = characters.transform.Find(string.Format("c{0}/Camera{1}",no ,no == 8 ? "Boss" : no.ToString())).GetComponent<Camera>().targetTexture;
        obj.transform.Find("Avatar").gameObject.GetComponent<RawImage>().texture = charImage;
        obj.transform.Find("Avatar").gameObject
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

        obj.transform.Find("Block").gameObject.GetComponent<Text>().text = string.Format("{0:000}" ,group.Resource.blockList.Count);
        obj.transform.Find("Team/TeamShow").gameObject.GetComponent<Image>().color = group.materialBall.color;

        if ( globalManager.CurrentPlayer != null && globalManager.CurrentPlayer.Equals(group) )
        {
            nowPlayerInfo.transform.Find("NowPlayer").gameObject.GetComponent<Text>().text = group.name;
            nowPlayerInfo.transform.Find("Army").gameObject.GetComponent<Text>().text = group.Resource.army.ToString();
            nowPlayerInfo.transform.Find("Civilian").gameObject.GetComponent<Text>().text = group.Resource.civilian.ToString();
            nowPlayerInfo.transform.Find("Antidote").gameObject.GetComponent<Text>().text = group.Resource.antidote.ToString();
            nowPlayerInfo.transform.Find("Mineral").gameObject.GetComponent<Text>().text = group.Resource.mineral.ToString();
            nowPlayerInfo.transform.Find("PlayerImage").gameObject.GetComponent<RawImage>().texture = obj.transform.Find("Avatar").gameObject.GetComponent<RawImage>().texture;

            obj.transform.Find("Round").gameObject.SetActive(true);
        }
        else
        {
            obj.transform.Find("Round").gameObject.SetActive(false);
        }
    }
}
