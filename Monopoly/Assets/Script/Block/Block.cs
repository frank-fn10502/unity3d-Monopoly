using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[JsonConverter(typeof(JsonSubtypes) ,"block_type")]
[JsonSubtypes.KnownSubType(typeof(BuildingBlock) ,"build")]
[JsonSubtypes.KnownSubType(typeof(EventBlock) ,"event")]
public abstract class Block
{
    public virtual string block_type { get; }//jsonconvert

    protected Vector3 location;
    protected List<Walkable> identity;
    protected List<Direction> directionList;
    protected List<Group> influenceList;

    protected Area       area;
    protected GameObject entity;

    public virtual Vector3 Location
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
    public List<Walkable> Identity
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
    public Area Area
    {
        get
        {
            return area;
        }

        set
        {
            area = value;
        }
    }
    public GameObject Entity
    {
        get
        {
            return entity;
        }

        set
        {
            entity = value;
        }
    }

    public Block()// : this(Vector3.zero, Walkable.NoMan ,Area.City)
    {
        this.identity = new List<Walkable>();
        this.directionList = new List<Direction>();
        this.influenceList = new List<Group>();
    }
    public Block(Vector2 location ,Walkable identity ,Area area) : this()
    {
        this.identity.Add(identity);

        this.location = location;
        this.area = area;
    }
    public Block(Block anotherBlock)
    {
        this.location = anotherBlock.location;
        this.identity = anotherBlock.identity;

        this.directionList = anotherBlock.directionList;
        this.influenceList = anotherBlock.influenceList;

        this.area = anotherBlock.area;
    }
    public void stopAction(Group group)
    {

    }
    public void build()
    {
        if ( this.Identity.Contains(Walkable.NoMan) || this.Identity.Contains(Walkable.ApeShortcut) )
        {
            setBackground(this.location);
        }
        else
        {
            setPath(this.location);
        }
    }


    /*==========private==========*/
    private void setPath(Vector3 location)
    {
        this.entity = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.entity.transform.localScale = new Vector3(8 ,0.2f ,8);

        Renderer renderer =  this.entity.GetComponent<Renderer>();

        if ( this.area == Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityLand");
        }
        else if ( this.area == Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestLand");
        }
        this.entity.transform.position = location;
    }
    private void setBackground(Vector3 location)
    {
        this.entity = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.entity.transform.localScale = new Vector3(0.8f ,1.0f ,0.8f);

        Renderer renderer =  this.entity.GetComponent<Renderer>();
        if ( this.area == Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityBackground");
        }
        else if ( this.area == Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestBackground");
        }
        this.entity.transform.position = location;
        this.entity.transform.position -= new Vector3(0 ,0.1f ,0);
    }
}
