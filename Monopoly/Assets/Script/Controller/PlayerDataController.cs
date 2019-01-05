using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataController : MonoBehaviour
{
    public  List<Faction> playerList;
    private List<Faction> factionList;
    private int currentPlayerIndex;

    private Texture currentTexture;
    private GameObject currentPlayerDisplay;
    private GameObject startButton;

    private const int playerNum = 4;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if ( factionList == null )
        {
            string path = Directory.GetCurrentDirectory();
            string target = @"\Assets\Resources\Faction\MonopolyFaction.json";
            string json = File.ReadAllText(path + target);
            factionList = JsonConvert.DeserializeObject<List<Faction>>(json);

            setCurrentCharacter(0);
            setCharacterFactions();

            playerList = new List<Faction>(playerNum);
            playerList.Add(null);
            playerList.Add(null);
            playerList.Add(null);
            playerList.Add(null);
            playerList.Add(factionList[factionList.Count - 1]);

            startButton = GameObject.Find("StartButton");
            startButton.SetActive(false);
        }
    }

    public void onSelectCharacter(int no)
    {
        if ( currentPlayerIndex < playerNum )
        {
            playerList[currentPlayerIndex] = factionList[no];
            currentTexture = GameObject.Find("c" + ( no + 1 ) + "Button").GetComponent<RawImage>().texture;
            currentPlayerDisplay.GetComponent<RawImage>().texture = currentTexture;
        }
    }
    public void onCheckoutClick()
    {
        if ( currentPlayerIndex < playerNum )
        {
            GameObject.Find("player" + ( currentPlayerIndex + 1 ) + "Button").SetActive(false);//temp
            setCurrentCharacter(currentPlayerIndex + 1);
        }
        if ( currentPlayerIndex == playerNum )
        {
            startButton.SetActive(true);
        }
    }


    /*==========setter=========*/
    private void setCharacterFactions()
    {
        string fileName;
        Faction.path = "PreFab/Building/MaterialBall/";
        string[] materialBallFileName = {"" ,"" ,"" ,"" ,"" ,"" ,"" ,""};

        for ( int i = 0 ; i < factionList.Count ; i++ )
        {
            factionList[i].fileName = materialBallFileName[i];
            //factionList[i].materialBall = Resources.Load<Material>(path + materialBallFileName[i]);
            //factionList[i].materialBall = GameObject.Instantiate(factionList[i].materialBall);

            if ( i == factionList.Count - 1 )
            {
                fileName = "boss/bossf";
            }
            else
            {
                fileName = "char" + ( i + 1 ) + "/cf" + ( i + 1 );
            }
            setFaction(i ,fileName);
        }
        Actor.Path = "PreFab/Character/char/";
    }
    private void setFaction(int no ,string fileName)
    {
        factionList[no].actorList = new List<Actor>();
        factionList[no].actorList.Add(new Actor());
        factionList[no].actorList[0].FileName = fileName;
    }

    private void setCurrentCharacter(int i)
    {
        currentPlayerIndex = i;
        currentPlayerDisplay = GameObject.Find("door" + ( currentPlayerIndex + 1 ));
    }
}
