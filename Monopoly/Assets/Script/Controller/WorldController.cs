using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GlobalManager globalManager;

    public void Awake()
    {
        //globalManager = new GlobalManager();
        GameObject gameObject = GameObject.Find("PlayerDataManager");
        List<Faction> factionList =  gameObject.GetComponent<PlayerDataController>().playerList;
        globalManager = new GlobalManager();

        GameObject.Destroy(gameObject);
    }
    void Update()
    {
        globalManager.execute();       
        changeView();
    }

    private void changeView()
    {
        gameObject.GetComponent<InformationPanelController>().changeCameraView(globalManager);
    }
}
