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
            setCharacterEntities();

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
        if(currentPlayerIndex < playerNum )
        {
            currentTexture = GameObject.Find("c" + ( no + 1 ) + "Button").GetComponent<RawImage>().texture;
            playerList[currentPlayerIndex] = factionList[no];
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
        if( currentPlayerIndex == playerNum)
        {
            startButton.SetActive(true);
        }
    }


    /*==========setter=========*/
    private void setCharacterEntities()
    {
        //int count = 6;
        for ( int i = 0 ; i < factionList.Count - 1 ; i++ )
        {
            factionList[i].actorList = new List<Actor>();
            factionList[i].actorList.Add(new Actor());
            factionList[i].actorList[0].Entity = Resources.Load<GameObject>("PreFab/Character/char/char" + (i + 1) + "/c" + (i + 1));
            factionList[i].actorList[0].FileName = "PreFab/Character/char/char" + ( i + 1 ) + "/c" + ( i + 1 );
        }
        factionList[factionList.Count - 1].actorList = new List<Actor>();
        factionList[factionList.Count - 1].actorList.Add(new Actor());
        factionList[factionList.Count - 1].actorList[0].Entity = Resources.Load<GameObject>(@"PreFab\Character\char\boss\boss");
    }
    private void setCurrentCharacter(int i)
    {
        currentPlayerIndex = i;
        currentPlayerDisplay = GameObject.Find("door" + ( currentPlayerIndex + 1 ));
    }
}
