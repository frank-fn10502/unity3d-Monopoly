using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockEntity
{   
    private BaseBlock  block;
    private Area       area;
    private GameObject entity;

    public BaseBlock Block
    {
        get
        {
            return block;
        }

        set
        {
            block = value;
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

    public BlockEntity(Area area)
    {
        this.block = null;
        this.Area = area;
    }
    [JsonConstructor]
    public BlockEntity(BaseBlock block ,Area area)
    {
        this.block = block;
        this.Area  = area;
    }

    public void build()
    {
        if ( block.Identity == Walkable.NoMan || block.Identity == Walkable.ApeShortcut )
        {
            setBackground(block.Location);
        }
        else
        {
            setPath(block.Location);
        }
    }
    private void setPath(Vector3 location)
    {
        this.Entity = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.Entity.transform.localScale = new Vector3(2 ,0.2f ,2);

        Renderer renderer =  this.Entity.GetComponent<Renderer>();

        if ( Area == Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityLand");
        }
        else if ( Area == Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestLand");
        }
        this.Entity.transform.position = location;
    }
    private void setBackground(Vector3 location)
    {
        this.Entity = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.Entity.transform.localScale = new Vector3(0.2f ,1.0f ,0.2f);

        Renderer renderer =  this.Entity.GetComponent<Renderer>();
        if ( Area == Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityBackground");
        }
        else if ( Area == Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestBackground");
        }
        this.Entity.transform.position = location;
        this.Entity.transform.position -= new Vector3(0 ,0.1f ,0);
    }
}
