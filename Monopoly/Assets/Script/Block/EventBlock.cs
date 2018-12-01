using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBlock : BaseBlock
{
    private EventPool eventPool;

    public EventBlock() : this(Vector3.zero ,Walkable.NoMan)
    {

    }
    public EventBlock(Vector2 location ,Walkable identity) : base(location ,identity)
    {
        eventPool = null;
    }
}
