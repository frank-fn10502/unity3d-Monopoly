using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GlobalManager globalManager;

    public void Awake()
    {
        globalManager = new GlobalManager();
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
