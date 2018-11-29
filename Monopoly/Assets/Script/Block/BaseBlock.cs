using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlock
{
    //image
    protected Vector2  Location;
    protected Walkable identity;
    protected bool[]   path;
    protected List<Group> influenceList;

    public void stopAction(Group group)
    {

    }
}
