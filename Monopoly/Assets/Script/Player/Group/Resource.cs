using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public int army;
    public int civilian;
    public int mineral;
    public int antidote;
    public List<Block> blockList;

    public Resource()
    {
        army = 0;
        civilian = 0;
        mineral = 0;
        antidote = 0;
        blockList = new List<Block>();
    }
    public Resource(int army ,int civilian ,int mineral)
    {
        this.army = army;
        this.civilian = civilian;
        this.mineral = mineral;
    }
    public Resource(Resource another)
    {
        army = another.army;
        civilian = another.civilian;
        mineral = another.mineral;
        antidote = another.antidote;
        blockList = new List<Block>();
    }
}
