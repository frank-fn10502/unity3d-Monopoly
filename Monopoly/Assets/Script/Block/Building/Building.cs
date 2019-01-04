using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building//TEMP
{
    public static string path;

    private GameObject entity;
    private string fileName;

    private string name;
    private Resource resource;


    public Resource Resource
    {
        get
        {
            return resource;
        }
    }
    public string FileName
    {
        get
        {
            return fileName;
        }

        set
        {
            fileName = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }



    public Building()
    {
        resource = new Resource(0 ,300 ,300);
    }
    public Building(string name ,string filePath) : this()
    {
        this.name = name;
        this.fileName = filePath;
    }
    public Building(Building another)
    {
        this.name = another.name;
        this.fileName = another.fileName;
        this.resource = new Resource(another.resource);
    }




    public void build(Group group ,Vector3 loc)
    {
        group.Resource.civilian -= resource.civilian;
        group.Resource.mineral -= resource.mineral;

        entity = Resources.Load<GameObject>(path + fileName);
        entity = GameObject.Instantiate(entity);
        entity.transform.position = loc;
    }
    public EventBase cost(List<Group> Group_list ,Group group)
    {
        EventBase eventBase = new DiplomaticEvent();
        eventBase.DoEvent(Group_list ,group);

        return eventBase;
    }
}
