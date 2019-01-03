using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    private string name;
    private string fileName;
    private Skill skill;
    private Dice  dice;

    private static string path;
    private GameObject entity;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public Skill Skill
    {
        get
        {
            return skill;
        }
    }
    public Dice Dice
    {
        get
        {
            return dice;
        }
    }
    public GameObject Entity
    {
        get
        {
            return entity;
        }
        set
        {
            entity = value;
        }
    }
    public static string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
    public string FileName
    {
        get
        {
            return fileName;
        }
        set
        {
            fileName = value;
        }
    }

    public Actor()
    {
        skill = null;
        dice = null;
    }

    public Actor(string name ,Skill skill ,Dice dice /*,Vector3 location = Vector3.zero*/ /*,Direction enterDirection*/)
    {
        this.name = name;
        this.skill = skill;
        this.dice = dice;
    }

    public void build(Vector3 location ,Direction enterDirection)
    {
        //fileName = "Player1";//temp
        //entity = Resources.Load<GameObject>("PreFab/Actor/" + fileName);
        entity = GameObject.Instantiate(entity);
        entity.transform.position = location;
        setRotation(enterDirection);
    }
    public void run(Vector3 location)
    {
        //播放動畫
        //entity.GetComponent<AnimationController>().running = true;

        teleport(location);
    }
    public void teleport(Vector3 location)
    {
        Quaternion quate = Quaternion.identity;
        if ( location.x > entity.transform.position.x )
        {
            quate.eulerAngles = new Vector3(0 ,90 ,0);
        }
        else if ( location.x < entity.transform.position.x )
        {
            quate.eulerAngles = new Vector3(0 ,270 ,0);
        }

        if ( location.z > entity.transform.position.z )
        {
            quate.eulerAngles = new Vector3(0 ,0 ,0);
        }
        else if ( location.z < entity.transform.position.z )
        {
            quate.eulerAngles = new Vector3(0 ,180 ,0);
        }
        entity.transform.rotation = quate;
        entity.transform.position = location + new Vector3(0 ,0.2f ,0);
    }
    public void stop()
    {
        //靜止動畫
        entity.GetComponent<AnimationController>().running = false;
    }
    //public int rollDice()
    //{
    //    //動畫
    //    //world.TotalStep = 50;//直接放數值
    //    //world.GameState = GameState.PlayerMovement;//玩家移動
    //    //world.CurrentGroup.State = PlayerState.SearchPath;//找道路
    //    return 0;
    //}

    private void setRotation(Direction enterDirection)
    {
        Quaternion quate = Quaternion.identity;
        switch ( enterDirection )
        {
            case Direction.West:
                quate.eulerAngles = new Vector3(0 ,0 ,0);
                break;
            case Direction.North:
                quate.eulerAngles = new Vector3(0 ,90 ,0);
                break;
            case Direction.East:
                quate.eulerAngles = new Vector3(0 ,180 ,0);
                break;
            case Direction.South:
                quate.eulerAngles = new Vector3(0 ,270 ,0);
                break;
        }
        this.entity.transform.rotation = quate;
    }
}
