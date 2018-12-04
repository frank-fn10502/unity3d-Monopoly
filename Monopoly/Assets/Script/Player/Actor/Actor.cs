using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    private string name;
    private Skill skill;
    private Dice  dice;
    private GameObject entity;
    private World world;
    public Actor(World world ,string name ,Skill skill ,Dice dice ,Vector3 location ,Direction enterDirection)
    {
        this.world = world;
        this.name = name;
        this.skill = skill;
        this.dice = dice;
        //建造實體
        entity = Resources.Load<GameObject>("PreFab/Actor/" + name);
        entity = GameObject.Instantiate(entity);
        //GameObject entity = new GameObject();
        entity.transform.position = location;
        setRotation(enterDirection);
    }

    public string Name
    {
        get
        {
            return name;
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


    public void run(Vector3 location)
    {
        //播放動畫
        entity.GetComponent<AnimationController>().running = true;

        Quaternion quate = Quaternion.identity;
        if ( location.x > entity.transform.position.x )
        {
            quate.eulerAngles = new Vector3(0 ,90 ,0);
        }
        else if ( location.x < entity.transform.position.x )
        {
            quate.eulerAngles = new Vector3(0 ,270 ,0);
        }

        if( location.z > entity.transform.position.z )
        {
            quate.eulerAngles = new Vector3(0 ,0 ,0);
        }
        else if( location.z < entity.transform.position.z )
        {                       
            quate.eulerAngles = new Vector3(0 ,180 ,0);
        }
        this.entity.transform.rotation = quate;
        entity.transform.position = location + new Vector3(0 ,0.2f ,0);
        //setRotation(enterDirection);
    }
    public void stop()
    {
        //靜止動畫
        entity.GetComponent<AnimationController>().running = false;
    }
    public int rollDice()
    {
        //動畫
        world.TotalStep = 3;//直接放數值
        world.CurrentGroup.State = PlayerState.findPath;//找道路
        return 0;
    }

    private void setRotation(Direction enterDirection)
    {
        Quaternion quate = Quaternion.identity;
        switch ( enterDirection )
        {
            case Direction.West:
                quate.eulerAngles = new Vector3(0 ,90 ,0);
                break;
            case Direction.North:
                quate.eulerAngles = new Vector3(0 ,180 ,0);
                break;
            case Direction.East:
                quate.eulerAngles = new Vector3(0 ,270 ,0);
                break;
            case Direction.South:
                quate.eulerAngles = new Vector3(0 ,0 ,0);
                break;
        }
        this.entity.transform.rotation = quate;
    }
}
