﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingEntity
{
    private BaseBuilding building;
    private GameObject   buildingEntity;

    public BuildingEntity(BaseBuilding building)
    {
        this.building = building;
    }
}