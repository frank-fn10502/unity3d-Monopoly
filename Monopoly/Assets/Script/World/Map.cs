using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Map
{
    private Vector3 startRowPos = new Vector3(0 , 0 ,0);
    //private Vector3 startRowPos = new Vector3(-15 , 0 ,-15);
    private int index;
    private Vector3 tempRowPos;
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

    public Vector3 StartRowPos
    {
        get
        {
            return startRowPos;
        }

        set
        {
            startRowPos = value;
        }
    }

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    public Vector3 TempRowPos
    {
        get
        {
            return tempRowPos;
        }

        set
        {
            tempRowPos = value;
        }
    }


    public Map()
    {
        BlockList = new Block[30 * 30];

        //createPassIdentity();
        //createPath();
    }

    public void build()
    {
        for ( int i = 0 ; i < 30 ; i++ )
        {
            for ( int j = 0 ; j < 30 ; j++ )
            {
                Index = i * 30 + j;
                //Debug.Log(i.ToString() + " " + blockEntityList[index].Identity.ToString());
                BlockList[Index].build();
            }
        }
    }
    /*
    private void createPassIdentity()
    {
        List<int[]> rows = new List<int[]>(30);
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { 16 });
        rows.Add(new int[] { 16 });
        rows.Add(new int[] { 16 });
        rows.Add(new int[] { });
        rows.Add(new int[] { 11 ,12 ,13 ,14 ,15 ,16 ,18 });
        rows.Add(new int[] { 16 ,18 });
        rows.Add(new int[] { 11 ,12 ,13 ,14 ,16 ,18 });
        rows.Add(new int[] { 11 ,16 ,18 });
        rows.Add(new int[] { 6 ,7 ,8 ,9 ,11 ,13 ,18 });
        rows.Add(new int[] { 11 ,13 ,15 ,16 ,17 ,18 });
        rows.Add(new int[] { 11 ,13 ,20 ,21 ,22 });
        rows.Add(new int[] { 11 ,13 ,14 ,15 ,16 ,17 ,18 });
        rows.Add(new int[] { });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { 11 });
        rows.Add(new int[] { });
        rows.Add(new int[] { });
        rows.Add(new int[] { });

        //設定誰可以走 & 區域設定
        int n;
        for ( int i = 0 ; i < 30 ; i++ )
        {
            n = 0;
            for ( int j = 0 ; j < 30 ; j++ )
            {
                Index = i * 30 + j;

                if ( rows[i].Length > 0 && j == rows[i][n] )
                {
                    BlockList[Index].Area = new Block(Area.Forest);
                    BlockList[Index] = new BuildingBlock();
                    BlockList[Index].Identity = Walkable.ApeShortcut;

                    n = ( ( n + 1 ) < rows[i].Length ? ++n : n );
                }
                else if ( ( i >= 10 && i <= 19 ) && ( j >= 10 && j <= 19 ) )
                {
                    BlockList[Index].Area = new Block(Area.Forest);
                    BlockList[Index] = new EventBlock();
                    BlockList[Index].Identity = Walkable.Ape;
                }
                else
                {
                    BlockList[Index].Area = new Block(Area.City);
                    BlockList[Index] = new BuildingBlock();
                }
            }
        }
    }
    private void createPath()
    {
        List<int[]> rows = new List<int[]>(30);
        rows.Add(new int[] { 0 ,1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,20 ,21 ,22 ,23 ,24 ,25 ,26 ,27 ,28 ,29 });
        rows.Add(new int[] { 0 ,2 ,4 ,7 ,10 ,16 ,29 });
        rows.Add(new int[] { 0 ,2 ,4 ,7 ,8 ,10 ,14 ,15 ,16 ,25 ,26 ,27 ,28 ,29 });
        rows.Add(new int[] { 0 ,2 ,4 ,8 ,10 ,14 ,25 ,29 });
        rows.Add(new int[] { 0 ,2 ,3 ,4 ,8 ,10 ,14 ,18 ,19 ,20 ,21 ,25 ,26 ,27 ,28 ,29 });
        rows.Add(new int[] { 0 ,7 ,8 ,10 ,14 ,15 ,18 ,21 ,22 ,29 });
        rows.Add(new int[] { 0 ,7 ,10 ,15 ,16 ,17 ,18 ,22 ,23 ,24 ,25 ,26 ,27 ,29 });
        rows.Add(new int[] { 0 ,5 ,6 ,7 ,10 ,16 ,27 ,29 });
        rows.Add(new int[] { 0 ,4 ,5 ,10 ,16 ,25 ,26 ,27 ,29 });
        rows.Add(new int[] { 0 ,4 ,10 ,16 ,25 ,29 });
        rows.Add(new int[] { 0 ,4 ,5 ,6 ,7 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,20 ,21 ,22 ,23 ,24 ,25 ,26 ,27 ,28 ,29 });
        rows.Add(new int[] { 0 ,7 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,29 });
        rows.Add(new int[] { 0 ,1 ,2 ,7 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,29 });
        rows.Add(new int[] { 0 ,2 ,5 ,6 ,7 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,29 });
        rows.Add(new int[] { 0 ,2 ,3 ,5 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,25 ,26 ,27 ,29 });
        rows.Add(new int[] { 0 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,24 ,25 ,27 ,29 });
        rows.Add(new int[] { 0 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,23 ,24 ,27 ,28 ,29 });
        rows.Add(new int[] { 0 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,20 ,21 ,22 ,23 ,29 });
        rows.Add(new int[] { 0 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,23 ,29 });
        rows.Add(new int[] { 0 ,1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,23 ,24 ,25 ,29 });
        rows.Add(new int[] { 0 ,4 ,11 ,19 ,25 ,29 });
        rows.Add(new int[] { 0 ,2 ,3 ,4 ,11 ,19 ,25 ,29 });
        rows.Add(new int[] { 0 ,2 ,6 ,7 ,8 ,11 ,13 ,14 ,15 ,16 ,19 ,24 ,25 ,29 });
        rows.Add(new int[] { 0 ,2 ,3 ,4 ,5 ,6 ,8 ,9 ,11 ,13 ,16 ,17 ,19 ,23 ,24 ,29 });
        rows.Add(new int[] { 0 ,9 ,11 ,13 ,17 ,19 ,22 ,23 ,29 });
        rows.Add(new int[] { 0 ,1 ,2 ,3 ,4 ,9 ,11 ,13 ,14 ,17 ,19 ,20 ,21 ,22 ,25 ,26 ,27 ,29 });
        rows.Add(new int[] { 0 ,4 ,9 ,11 ,14 ,17 ,19 ,25 ,27 ,29 });
        rows.Add(new int[] { 0 ,1 ,2 ,3 ,4 ,9 ,10 ,11 ,12 ,13 ,14 ,17 ,19 ,25 ,27 ,29 });
        rows.Add(new int[] { 0 ,17 ,19 ,25 ,27 ,29 });
        rows.Add(new int[] { 0 ,1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,10 ,11 ,12 ,13 ,14 ,15 ,16 ,17 ,18 ,19 ,20 ,21 ,22 ,23 ,24 ,25 ,26 ,27 ,28 ,29 });

        int n;
        for ( int i = 0 ; i < 30 ; i++ )
        {
            n = 0;
            for ( int j = 0 ; j < 30 ; j++ )
            {
                Index = i * 30 + j;
                TempRowPos = StartRowPos + new Vector3(i * 2 ,0 ,j * 2);

                BlockList[Index].Location = TempRowPos;

                if ( j == rows[i][n] )
                {
                    n = ( ( n + 1 ) < rows[i].Length ? ++n : n );

                    if( BlockList[Index].Identity == Walkable.NoMan)
                    {
                        BlockList[Index].Identity = Walkable.Human;
                    }                        
                }
            }
        }
    }
    */
}