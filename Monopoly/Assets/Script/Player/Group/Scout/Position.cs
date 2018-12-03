using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public Direction enterDirection;
    public int blockIndex;
    public BaseBlock block;
    public Vector3   location;
    public GameObject entity;

    public Position(Direction enterDirection ,int blockIndex ,BaseBlock block ,Vector3 location)
    {
        this.enterDirection = enterDirection;
        this.blockIndex = blockIndex;
        this.block = block;
        this.location = location;
    }

    public void buildEntity()
    {
        this.entity = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        this.entity.transform.localScale = new Vector3(0.4f ,0.1f ,0.4f);

        Renderer renderer =  this.entity.GetComponent<Renderer>();
        renderer.material = Resources.Load<Material>("Texture/Orange");

        this.entity.transform.position = location + new Vector3(0 ,0.2f ,0);
    }
    public void beSelected()
    {
        //變色
    }
}