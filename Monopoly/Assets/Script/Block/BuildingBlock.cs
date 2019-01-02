using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingBlock : Block
{
    public override string block_type { get; } = "build";//jsonconvert

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




    public override void stopAction(Group group)
    {
        if(building == null)
        {
            //呼叫建立房子
        }
        else
        {
            //收費
        }
    }
    public override Vector3 standPoint()
    {
        return pathLocations[0];
    }
    public override Vector3 standPoint(Vector3 preLoc)
    {
        Vector3 v = pathLocations[0];
        if ( PathLocations.Count > 1 )
        {
            Vector3 v1 = pathLocations[0] - preLoc;
            Vector3 v2 = pathLocations[1] - preLoc;
            if ( v1.magnitude == 0f )
            {
                v = pathLocations[1];
            }
            else if ( v2.magnitude == 0f )
            {
                v = pathLocations[0];
            }
            else if ( v1.magnitude > v2.magnitude )
            {
                v = pathLocations[1];
            }
        }
        return v;
        //return new List<Vector3>(pathLocations);
    }

    /*==========private==========*/
    //private List<Vector3> sortPathLocation()
    //{
    //    if ( buildingLocation - location == new Vector3(-2 ,0 ,0) )
    //    {
    //        return new List<Vector3>() { pathLocations[1] ,pathLocations[0] };
    //    }
    //    else if ( buildingLocation - location == new Vector3(0 ,0 ,2) )
    //    {
    //        return new List<Vector3>() { pathLocations[1] ,pathLocations[0] };
    //    }
    //    else if ( buildingLocation - location == new Vector3(0 ,0 ,-2) )
    //    {
    //        return new List<Vector3>() { pathLocations[1] ,pathLocations[0] };
    //    }
    //    else if ( buildingLocation - location == new Vector3(2 ,0 ,0) )
    //    {
    //        return new List<Vector3>() { pathLocations[0] ,pathLocations[1] };
    //    }
    //    return null;
    //}
}
