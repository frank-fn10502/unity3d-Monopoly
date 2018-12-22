using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventBlock : Block
{
    private EventPool eventPool;

    public EventBlock() : this(Vector3.zero, Walkable.NoMan ,Area.City)
    {

    }
    public EventBlock(Vector2 location, Walkable identity ,Area area) : base(location, identity ,area)
    {
        eventPool = null;
    }
}
