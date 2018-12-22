using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public World world;

    void Start()
    {
        world = new World();
    }
    void Update()
    {
        world.execute();       
        changeView();
    }

    private void changeView()
    {
        this.gameObject.GetComponent<InformationPanelController>().changeCameraView(world);
    }
}
