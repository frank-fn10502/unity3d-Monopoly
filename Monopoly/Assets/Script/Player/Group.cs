using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group
{
    private PlayerState state;
    private Walkable    identity;
    private Skill   skill;
    private Actor[] actor;
    private int     currentActor;

    private Attributes attributes;
    private Resource   resource;
    private Vector3    location;

    private int       blockIndex;
    private Direction enterDirection;

    public void move(Vector3 now ,Vector3 next ,int step)
    {
        float x = (next.x - now.x) * step / Constants.STEPTIMES;
        float z = (next.z - now.z) * step / Constants.STEPTIMES;

        location = new Vector3(now.x + x ,Constants.SEALEVEL ,now.z + z);
    }
}
