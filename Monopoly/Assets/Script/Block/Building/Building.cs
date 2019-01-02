using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building//TEMP
{
    private GameObject entity;
    private string filePath;

    private string name;
    private Resource resource;

    public Building()
    {
        resource = new Resource(0 ,500 ,1000);
    }
    public Building(string name ,string filePath) : this()
    {
        this.name = name;
        this.filePath = filePath;       
    }



    public void build(Group group)
    {
        //減少資源
        entity = Resources.Load<GameObject>(filePath);
    }
    

    private void cost(Resource playerR)
    {
        playerR.army -= resource.army;
    }
}
