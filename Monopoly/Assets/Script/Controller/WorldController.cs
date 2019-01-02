using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GlobalManager world;

    public void Awake()
    {
        world = new GlobalManager();
    }
    void Update()
    {
        world.execute();       
        changeView();
    }

    private void changeView()
    {
        gameObject.GetComponent<InformationPanelController>().changeCameraView(world);
    }
}
