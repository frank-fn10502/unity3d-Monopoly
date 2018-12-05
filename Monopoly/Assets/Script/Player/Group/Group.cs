﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group
{
    private PlayerState state;
    private Walkable    identity;
    private Skill skill;
    private Actor[] actors;
    private int     currentActor;

    private Attributes attributes;
    private Resource   resource;
    private Vector3    location;

    private int currentBlockIndex;
    private Direction enterDirection;

    private Scout scout;
    private int stepCount;
    

    public Group(Skill skill ,Actor[] actors  ,Attributes attributes ,Resource resource ,Vector3 location ,int currentBlockIndex ,Direction enterDirection)
    {
        this.state = PlayerState.rollingDice;
        this.identity = Walkable.Human;
        this.skill = skill;
        this.actors = actors;
        this.currentActor = 0;

        this.attributes = attributes;
        this.resource   = resource;
        this.location = location;
        this.currentBlockIndex = currentBlockIndex;
        this.enterDirection = enterDirection;

        this.scout = new Scout(this);
    }

    public Actor CurrentActor
    {
        get { return actors[currentActor]; }
    }
    public Walkable Identity
    {
        get { return identity; }
    }
    public PlayerState State
    {
        get { return state; }
        set { state = value; }
    }
    public Attributes Attributes
    {
        get
        {
            return attributes;
        }
    }
    public Resource Resource
    {
        get
        {
            return resource;
        }
    }
    public Vector3 Location
    {
        get
        {
            return location;
        }
        set
        {
            location = value;
        }
    }
    public Direction EnterDirection
    {
        get
        {
            return enterDirection;
        }

        set
        {
            enterDirection = value;
        }
    }
    public Skill Skill
    {
        get
        {
            return skill;
        }
    }
    public int CurrentBlockIndex
    {
        get
        {
            return currentBlockIndex;
        }

        set
        {
            currentBlockIndex = value;
        }
    }



    public void changeActor(int rotate)//1 or -1
    {
        int next  = currentActor - rotate;
        next = ( next < 0 ) ? Constants.ACTORTOTALNUM + next
                            : next % Constants.ACTORTOTALNUM;

        this.currentActor = next;
    }
    public void rollDice()//扔骰子
    {
        CurrentActor.rollDice();
    }
    public void findPathList(Map map ,int step)//找到所有可以走的路
    {
        scout.reconnoiter(map ,step);     
        stepCount = 0;
    }
    public void move()//按照scout的Path移動
    {       
        if ( scout.totalStep != 0 )
        {
            move(scout.choicePath[0].location
                ,scout.choicePath[1].location ,++stepCount);
            //move(scout.choicePath[0].location
            //    ,new Vector3(-15 ,0 ,-11) ,++stepCount);
        }
        else if ( scout.totalStep == 0 )
        {
            actors[currentActor].stop();          
            //block.stopAction();
            //this.EnterDirection = scout.choicePath[0].enterDirection;
            scout.deleteDot(scout.choicePath[0]);//刪除走過的點
            state = PlayerState.nextPlayer;
            Debug.Log("state " + state);
        }
        if ( stepCount == Constants.STEPTIMES )
        {       
            stepCount = 0;

            if ( CurrentBlockIndex != scout.choicePath[1].blockIndex )
            {
                this.EnterDirection    = scout.choicePath[1].enterDirection;
                this.CurrentBlockIndex = scout.choicePath[1].blockIndex;
                --scout.totalStep;
            }
            //this.CurrentBlockIndex = scout.choicePath[0].blockIndex;
            //--scout.totalStep;

            scout.deleteDot(scout.choicePath[0]);//刪除走過的點
            Debug.Log("scout.totalStep: " + scout.totalStep);
        }
    }

    private void move(Vector3 now ,Vector3 next ,int step)
    {
        float x = (next.x - now.x) * step / Constants.STEPTIMES;// * Time.deltaTime;
        float z = (next.z - now.z) * step / Constants.STEPTIMES;// * Time.deltaTime;
        location = new Vector3(now.x + x ,Constants.SEALEVEL ,now.z + z);
        Debug.Log(location);
        Debug.Log("next: " + next + "now: " + now);
        

        actors[currentActor].run(location);
    }
}