using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class EventBase
{
    private string name;
    private bool isGood;
    private int weight;
    private string detail;
    private string image;
    private Group winer;
    PlayerState state;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
public bool IsGood
    {
        get { return isGood; }
        set { isGood = value; }
    }
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Detail
    {
        get { return detail; }
        set { detail = value; }
    }
    public string Image
    {
        get { return image; }
        set { image = value; }
    }
    public PlayerState State
    {
        get { return state; }
        set { state = value; }
    }
    public Group Winer
    {
        get { return Winer; }
        set { Winer = value; }
    }
    public EventBase(string n = "", bool g= true ,int w = 1, string d = "",string p = "")
    {
        name = n;
        isGood = g;
        weight = w;
        detail = d;
        image = p;
    }

    public abstract void DoEvent(List<Group> droup_list, Group group);
}
public class DiplomaticEvent : EventBase
{
    public override void DoEvent(List<Group> droup_list ,Group group)
    {
        BuildingBlock buildingBlock = (BuildingBlock)Group.blockList[group.CurrentBlockIndex];
        group.Resource.civilian -= buildingBlock.Building.Resource.civilian;
        group.Resource.mineral -= buildingBlock.Building.Resource.mineral;

        this.Name = "外交: 給予資源";
        this.Image = "EventImage/AllEvent";
        this.Detail = "civilian - " + buildingBlock.Building.Resource.civilian + "\n" +
                      "mineral - " + buildingBlock.Building.Resource.mineral;
    }
}