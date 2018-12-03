using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract
[System.Serializable]
public class BaseBlock
{
    protected Vector3 location;
    protected Walkable identity;
    protected List<Direction> directionList;
    protected List<Group> influenceList;

    public Vector3 Location
    {
        get
        {
            return location;
        }

        set
        {
            location = value;
        }
    }
    public Walkable Identity
    {
        get
        {
            return identity;
        }

        set
        {
            identity = value;
        }
    }
    public List<Direction> DirectionList
    {
        get
        {
            return directionList;
        }

        set
        {
            directionList = value;
        }
    }
    public List<Group> InfluenceList
    {
        get
        {
            return influenceList;
        }

        set
        {
            influenceList = value;
        }
    }

    public BaseBlock() : this(Vector3.zero, Walkable.NoMan)
    {
    }
    public BaseBlock(Vector2 location, Walkable identity)
    {
        this.location = location;
        this.identity = identity;

        directionList = new List<Direction>();
        influenceList = new List<Group>();
    }

    public void stopAction(Group group)
    {

    }
}
