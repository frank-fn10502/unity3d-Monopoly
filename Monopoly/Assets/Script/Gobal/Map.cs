using UnityEngine;

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
                BlockList[index].build("block "+ index);
                if ( BlockList[index].Entity != null )
                {
                    BlockList[index].Entity.transform.parent = mapEntity.transform;//統一管理

                    GameObject gameObject = Resources.Load<GameObject>("PreFab/Block/Frame");
                    gameObject = GameObject.Instantiate(gameObject);                   
                    gameObject.transform.position = BlockList[index].Entity.transform.position + new Vector3(0 ,0.2f ,0);
                    gameObject.transform.parent = mapEntity.transform;//統一管理

                    BlockList[index].frame = gameObject;
                }
            }
        }
    }
}