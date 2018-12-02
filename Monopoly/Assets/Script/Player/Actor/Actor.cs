using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    private string name;
    private Skill skill;
    private Dice  dice;
    private GameObject entity;

    public Actor(string name ,Skill skill ,Dice dice ,Vector3 location)
    {
        this.name = name;
        this.skill = skill;
        this.dice = dice;
        //建造實體
        GameObject entity = new GameObject();
        renderer.material = Resources.Load<GameObject>("PreFab/" + name);
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
    }
    public void stop()
    {
        //靜止動畫
    }
    public int rollDice()
    {
        //動畫
        return 0;
    }
}
