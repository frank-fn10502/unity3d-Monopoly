﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    private string name;
    private Skill skill;
    private Dice  dice;
    private GameObject entity;
    private World world;

    public Actor(World world ,string name ,Skill skill ,Dice dice ,Vector3 location)
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
        entity.transform.position = location + new Vector3(0 ,0.2f ,0);
    }
    public void stop()
    {
        //靜止動畫
        entity.GetComponent<AnimationController>().running = false;
    }
    public int rollDice()
    {
        //動畫
        world.TotalStep = 0;//直接放數值
        world.CurrentGroup.State = PlayerState.findPath;//找道路
        return 0;
    }
}
