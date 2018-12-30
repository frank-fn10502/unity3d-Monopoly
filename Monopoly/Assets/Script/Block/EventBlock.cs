using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBlock : Block
{
    public override string block_type { get; } = "event";//jsonconvert

    private EventPool eventPool;


    public EventBlock() : base()// : this(Vector3.zero, Walkable.NoMan ,Area.City)
    {
        eventPool = null;
    }
    public EventBlock(Vector2 location ,Walkable identity ,Area area) : base(location ,identity ,area)
    {
        eventPool = null;
    }
    public EventBlock(Block anotherBlock) : base(anotherBlock)
    {
        eventPool = null;
    }
}
