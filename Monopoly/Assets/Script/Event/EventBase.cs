using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class EventBase
{
    private string name;
    private string detail;
    private bool isGood;
    private int weight;   
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
    public PlayerState State
    {
        get { return state; }
        set { state = value; }
    }
    public EventBase(string n = "", bool g= true ,int w = 1, string d = "")
    {
        name = n;
        isGood = g;
        weight = w;
        detail = d;
    }

    public abstract void DoEvent(List<Group> droup_list, Group group);
}
