using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingBlock : BaseBlock
{
    private Group Landlord;
    private BuildingEntity buildingEntity;
    public override string block_type { get; } = "build";
    public Group Landlord1
    {
        get
        {
            return Landlord;
        }

        set
        {
            Landlord = value;
        }
    }
    public BuildingEntity BuildingEntity
    {
        get
        {
            return buildingEntity;
        }

        set
        {
            buildingEntity = value;
        }
    }

    public BuildingBlock() : this(Vector3.zero, Walkable.NoMan)
    {

    }
    public BuildingBlock(Vector2 location, Walkable identity) : base(location, identity)
    {
        Landlord = null;
        buildingEntity = null;
    }
}
