using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEntity
{    
    private GameObject blockEntity;
    private BaseBlock  block;
    private Area       area;

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

    public BlockEntity(Area area)
    {
        this.block = null;
        this.area = area;
    }
    public BlockEntity(BaseBlock block ,Area area)
    {
        this.block = block;
        this.area  = area;
    }

    public void build()
    {
        if ( block.Identity == Walkable.NoMan || block.Identity == Walkable.Ape )
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
        this.blockEntity = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.blockEntity.transform.localScale = new Vector3(2 ,0.2f ,2);

        Renderer renderer =  this.blockEntity.GetComponent<Renderer>();

        if ( area == Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityLand");
        }
        else if ( area == Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestLand");
        }
        this.blockEntity.transform.position = location;
    }
    private void setBackground(Vector3 location)
    {
        this.blockEntity = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.blockEntity.transform.localScale = new Vector3(0.2f ,1.0f ,0.2f);

        Renderer renderer =  this.blockEntity.GetComponent<Renderer>();
        if ( area == Area.City )
        {
            renderer.material = Resources.Load<Material>("Texture/CityBackground");
        }
        else if ( area == Area.Forest )
        {
            renderer.material = Resources.Load<Material>("Texture/ForestBackground");
        }
        this.blockEntity.transform.position = location;
        this.blockEntity.transform.position -= new Vector3(0 ,0.1f ,0);
    }
}
