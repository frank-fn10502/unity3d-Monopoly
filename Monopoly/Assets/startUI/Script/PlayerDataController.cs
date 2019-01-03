using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    public  List<Faction> playerList;
    private List<Faction> factionList;    
    private List<GameObject> playerEntityList;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if( factionList == null)
        {
            string path = Directory.GetCurrentDirectory();
            string target = @"\Assets\Resources\Faction\MonopolyFaction.json";
            string json = File.ReadAllText(path + target);
            factionList = JsonConvert.DeserializeObject<List<Faction>>(json);


            //playerList = new List<Faction>();
            playerList = factionList;//temp
        }
    }


    void Update()
    {

    }
}
