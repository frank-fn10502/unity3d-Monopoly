using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlock
{
    //image
    protected Vector2  Location;
    protected Walkable identity;
    protected List<Direction> directionList;
    protected List<Group> influenceList;

    public BaseBlock()
    {
        directionList = new List<Direction>();
    }

    public void stopAction(Group group)
    {

    }
}
