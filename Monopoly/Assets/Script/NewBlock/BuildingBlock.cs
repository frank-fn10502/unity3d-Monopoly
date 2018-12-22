using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingBlock : Block
{
    private Group landlord;
    private Building building;

    public Group Landlord1
    {
        get
        {
            return landlord;
        }

        set
        {
            landlord = value;
        }
    }
    public Building Building
    {
        get
        {
            return building;
        }

        set
        {
            building = value;
        }
    }

    public BuildingBlock() : this(Vector3.zero, Walkable.NoMan ,Area.City)
    {

    }
    public BuildingBlock(Vector2 location, Walkable identity ,Area area) : base(location, identity ,area)
    {
        this.landlord = null;
        this.building = null;
    }
}
