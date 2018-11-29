using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group
{
    private PlayerState state;
    private Walkable    identity;
    private Skill skill;
    private Actor[] actor;
    private Actor currentActor;
    private Attributes attributes;
    private Resource resource;

    private Vector2 Location;
    private Direction enterDirection;
    private BaseBlock currentBlock;
}
