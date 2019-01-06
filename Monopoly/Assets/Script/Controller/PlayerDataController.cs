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
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F12))
        {
            System.Random random = new System.Random();
            int r;
            for (int i = 0; i < 4; i++)
            {
                r = random.Next(0 ,7);

                onSelectCharacter(r);
                onCheckoutClick();
            }
        }
    }

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

            //buttonList = new List<GameObject>();
            //for ( int i = 0 ; i < 4 ; i++ )
            //{
            //    buttonList.Add(GameObject.Find("player" + ( i + 1 ) + "Button"));
            //    buttonList[i].SetActive(false);
            //}
            //buttonList[0].SetActive(true);
        }
        //for(int i = 0; i < 4; i++)
        //{
        //    onSelectCharacter(i);
        //    onCheckoutClick();
        //}
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
        if ( playerList[currentPlayerIndex] != null )
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
            //else
            //{
            //    buttonList[currentPlayerIndex].SetActive(true);
            //}
        }
    }


    /*==========setter=========*/
    private void setCharacterFactions()
    {
        string fileName;
        Faction.path = "PreFab/Building/MaterialBall/";
        string[] materialBallFileName = {"M1" ,"M2" ,"M3" ,"M4" ,"M5" ,"M6" ,"M7" ,"M8"};

        for ( int i = 0 ; i < factionList.Count ; i++ )
        {
            factionList[i].fileName = materialBallFileName[i];
            factionList[i].materialBall = Resources.Load<Material>(Faction.path + materialBallFileName[i]);
            factionList[i].materialBall = GameObject.Instantiate(factionList[i].materialBall);

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
