using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlock : Block
{
    private List<Vector3> pathLocations;
    private Vector3 buildingLocation;
    private Group landlord;
    private Building building;

    public override Vector3 Location
    {
        get
        {
            return location;
        }

        set
        {
            location = value;
            buildingLocation = location + new Vector3(-2 ,0 ,0);
        }
    }
    public List<Vector3> PathLocations
    {
        get
        {
            return pathLocations;
        }

        set
        {
            pathLocations = value;
        }
    }
    public Vector3 BuildingLocation
    {
        get
        {
            return buildingLocation;
        }

        set
        {
            buildingLocation = value;
        }
    }
    public Group Landlord
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



    public BuildingBlock() : base()// : this(Vector3.zero ,Walkable.NoMan ,Area.City)
    {
        this.landlord = null;
        this.building = null;
        pathLocations = new List<Vector3>();
    }
    public BuildingBlock(Vector2 location ,Walkable identity ,Area area) : base(location ,identity ,area)
    {
        this.landlord = null;
        this.building = null;

        pathLocations = new List<Vector3>();
    }
    public BuildingBlock(Block anotherBlock) : base(anotherBlock)
    {
        this.landlord = null;
        this.building = null;

        pathLocations = new List<Vector3>();
    }
}
