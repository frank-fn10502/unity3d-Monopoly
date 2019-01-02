﻿using UnityEngine;

[System.Serializable]
public class Map
{
    private Block[] blockList;

    public Block[] BlockList
    {
        get
        {
            return blockList;
        }

        set
        {
            blockList = value;
        }
    }


    public Map()
    {
        BlockList = new Block[30 * 30];
    }

    public void build()
    {
        GameObject mapEntity = new GameObject("mapEntity");//Empty GameObject
        for ( int i = 0, index ; i < 30 ; i++ )
        {
            for ( int j = 0 ; j < 30 ; j++ )
            {
                index = i * 30 + j;
                BlockList[index].build();
                BlockList[index].Entity.transform.parent = mapEntity.transform;//統一管理
            }
        }
    }
}