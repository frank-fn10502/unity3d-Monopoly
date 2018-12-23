using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Block
{
    private Vector3 location;
    private Walkable identity;
    private List<Direction> directionList;
    private List<Group> influenceList;

    private Area       area;
    private GameObject entity;

    public virtual string block_type { get; }
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

    public Block() : this(Vector3.zero, Walkable.NoMan ,Area.City)
    {
    }
    public Block(Vector2 location, Walkable identity ,Area area)
    {
        this.location = location;
        this.identity = identity;

        this.directionList = new List<Direction>();
        this.influenceList = new List<Group>();

        this.area = area;
    }

    public void stopAction(Group group)
    {

    }
    public void build()
    {
        if ( this.Identity == Walkable.NoMan || this.Identity == Walkable.ApeShortcut )
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
        this.entity.transform.localScale = new Vector3(2 ,0.2f ,2);

        Renderer renderer =  this.entity.GetComponent<Renderer>();

        if (this.area== Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityLand");
        }
        else if (this.area== Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestLand");
        }
        this.entity.transform.position = location;
    }
    private void setBackground(Vector3 location)
    {
        this.entity = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.entity.transform.localScale = new Vector3(0.2f ,1.0f ,0.2f);

        Renderer renderer =  this.entity.GetComponent<Renderer>();
        if (this.area== Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityBackground");
        }
        else if (this.area== Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestBackground");
        }
        this.entity.transform.position = location;
        this.entity.transform.position -= new Vector3(0 ,0.1f ,0);
    }
}
