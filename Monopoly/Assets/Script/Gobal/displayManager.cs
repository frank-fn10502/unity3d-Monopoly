using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class DisplayManager
{
    private GlobalManager globalManager;
    private GameObject nextPlayerText;
    private GameObject pathListEntity;
    private GameObject eventCard;
    private GameObject strategyCard;//
    private int timer;

    public Group currentPlayer
    {
        get
        {
            return globalManager.CurrentPlayer;
        }
    }



    public DisplayManager(GlobalManager globalManager)
    {
        this.globalManager = globalManager;

        nextPlayerText = Resources.Load<GameObject>("PreFab/Ui/NextPlayerText");
        nextPlayerText = GameObject.Instantiate(nextPlayerText ,new Vector3(33 ,-66.25f ,0) ,Quaternion.identity);
        nextPlayerText.transform.SetParent(GameObject.Find("Canvas").transform ,false);

        pathListEntity = new GameObject("pathListEntity"); //Empty GameObject

        eventCard = GameObject.Find("EventCardDisplay");
        eventCard.SetActive(false);
        eventCard.GetComponent<EventCardController>().globalManager = globalManager;
    }

    public void displayRollingDice()
    {
        //呼叫扔骰子
        globalManager.TotalStep = 12;//temp
        currentPlayer.State = PlayerState.SearchPath;//temp
    }
    public void displaySearchPath(Map map)
    {
        createScoutPathEntity(map);
        createInteractiveDot();
    }
    public void displayPlayerMovement()
    {
        currentPlayer.CurrentActor.run(currentPlayer.Location);

        if ( currentPlayer.Scout.totalStep == 0 )
        {
            currentPlayer.Scout.deleteDot(currentPlayer.Scout.choicePath[0]);//刪除走過的點
            //currentPlayer.CurrentActor.stop();

            currentPlayer.State = PlayerState.End;
        }
    }
    public void displayEvent(EventBase eventData ,GameState nextGameState)
    {
        //顯示事件卡
        eventCard.transform.Find("EventTitle").GetComponent<Text>().text = eventData.Name;
        eventCard.transform.Find("EventImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(eventData.Image);
        eventCard.transform.Find("EventDes").GetComponent<Text>().text = eventData.Detail;
        
        eventCard.GetComponent<EventCardController>().nextGameState = nextGameState;
        eventCard.SetActive(true);
    }
    public void displayStopAction(Block block ,GameState nextGameState)
    {
        if(block is EventBlock)
        {
            EventBase eventData = globalManager.Events.doEvent(Eventtype.Forest 
                                                              ,new List<Group>( globalManager.GroupList) 
                                                              ,globalManager.CurrentPlayer);

            displayEvent(eventData ,nextGameState);
        }
        else if(block is BuildingBlock)
        {
            BuildingBlock buildingBlock = (BuildingBlock)block;
            if ( buildingBlock.Building == null)
            {
                //建造建築物
            }
            else
            {
                strategyCard.GetComponent<StrategyCardController>().nextGameState = nextGameState;
                strategyCard.SetActive(true);
            }
        }
    }

    public void displayNextPlayer()
    {
        if ( timer % 500 == 0 )
        {
            bool now = nextPlayerText.activeSelf;
            nextPlayerText.SetActive(!now);

        }
        timer = ( timer + 10 ) % 500;

        if ( Input.anyKey )
        {
            nextPlayerText.SetActive(false);
            globalManager.nextPlayer();           
        }
    }

    /*==========private==========*/
    /*==========ScoutPathEntity==========*/
    private void createScoutPathEntity(Map map)
    {
        int[] markMap  = new int[map.BlockList.Length];
        int[] duplicateMap  = new int[map.BlockList.Length];
        for ( int i = 0 ; i < markMap.Length ; i++ ) { markMap[i] = 0; }//全部標記為 "未走過"

        Position onePos;
        for ( int i = 0 ; i < currentPlayer.Scout.pathList.Count ; i++ )
        {
            for ( int k = 0 ; k < map.BlockList.Length ; k++ )
            {
                duplicateMap[k] = 0;
            }

            for ( int j = 0 ; j < currentPlayer.Scout.pathList[i].Count ; j++ )
            {
                onePos = currentPlayer.Scout.pathList[i][j];
                if(onePos.entity == null)
                {
                    if( markMap[onePos.blockIndex] == 0 || (markMap[onePos.blockIndex] == 1 && onePos.block is BuildingBlock) )
                    {
                        markMap[onePos.blockIndex]++;
                        buildEntity(onePos ,onePos.blockIndex ,markMap[onePos.blockIndex]);
                        onePos.entity.transform.parent = pathListEntity.transform;//統一放到一個Empty的GameObject下面
                    }
                    else
                    {
                        try
                        {
                            duplicateMap[onePos.blockIndex]++;
                            onePos.entity = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-" + duplicateMap[onePos.blockIndex]).gameObject;//如果有了就不要再建造一次 直接指定
                            if( onePos.block is BuildingBlock )
                            {
                                duplicateMap[onePos.blockIndex] %= 2;
                            }
                            else
                            {
                                duplicateMap[onePos.blockIndex] = 0;
                            }
                        }
                        catch
                        {
                            Debug.Log("test");
                        }                       
                    }                   
                }
                //if ( ( markType[onePos.blockIndex] == -1 || markType[onePos.blockIndex] == i ) && markMap[onePos.blockIndex] < 2 )//if沒有建過 "這一個點"
                //{
                //    markMap[onePos.blockIndex]++;
                //    markType[onePos.blockIndex] = i;

                //    buildEntity(onePos ,onePos.blockIndex ,markMap[onePos.blockIndex]);
                //    onePos.entity.transform.parent = pathListEntity.transform;//統一放到一個Empty的GameObject下面
                //}
                //else
                //{
                //    try
                //    {
                //        //markMap[onePos.blockIndex]++;
                //        markMap[onePos.blockIndex] = markMap[onePos.blockIndex] % 2 + 1;
                //        onePos.entity = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-" + markMap[onePos.blockIndex]).gameObject;//如果有了就不要再建造一次 直接指定
                //    }
                //    catch
                //    {
                //    }
                //}
            }
        }
    }
    private void buildEntity(Position onePos ,int mapIndex ,int offset)
    {
        onePos.entity = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        onePos.entity.transform.name = "dot" + mapIndex + "-" + offset;
        onePos.entity.transform.localScale = new Vector3(0.8f ,0.1f ,0.8f);

        onePos.entity.GetComponent<Renderer>().material = Resources.Load<Material>("Texture/Orange");

        onePos.entity.transform.position = ( onePos.location + new Vector3(0 ,0.2f ,0) );
    }
    private void createInteractiveDot()
    {
        int count = 0;
        foreach ( List<Position> onePath in currentPlayer.Scout.pathList )
        {
            GameObject entity = onePath[onePath.Count - 1].entity;

            if( entity.GetComponent<PositionController>() == null)
            {
                entity.AddComponent<PositionController>();
                entity.GetComponent<PositionController>().pathNo = count;
                entity.GetComponent<PositionController>().CheckOut = currentPlayer.Scout.checkOutPath;
                entity.GetComponent<PositionController>().Select = currentPlayer.Scout.selectPath;
                entity.GetComponent<PositionController>().Leave = currentPlayer.Scout.leavePath;
                entity.transform.localScale = new Vector3(2f ,0.1f ,2f);
            }
            count++;
        }
        //if ( currentPlayer.Scout.pathList.Count == 1 )
        //{
        //    currentPlayer.Scout.checkOutPath(0);
        //}
    }
}

