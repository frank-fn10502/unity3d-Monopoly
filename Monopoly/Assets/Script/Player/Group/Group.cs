using UnityEngine;

public class Group
{
    private Block[] blockList;
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
    private int  inJailTime;
    private int stepCount;


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
    public Scout Scout
    {
        get
        {
            return scout;
        }
    }
    public int InJailTime
    {
        get
        {
            return inJailTime;
        }

        set
        {
            inJailTime = value;
        }
    }
    public Block[] BlockList
    {
        get
        {
            return blockList;
        }
    }

    public Group(Block[] blockList , Skill skill ,Actor[] actors ,Attributes attributes ,Resource resource ,Vector3 location ,int currentBlockIndex ,Direction enterDirection)
    {
        this.blockList = blockList;
        this.state = PlayerState.Normal;
        this.identity = Walkable.Human;
        this.skill = skill;
        this.actors = actors;
        this.currentActor = 0;

        this.attributes = attributes;
        this.resource = resource;
        this.location = location;
        this.currentBlockIndex = currentBlockIndex;
        this.enterDirection = enterDirection;

        this.scout = new Scout(this);
        this.inJailTime = 0;
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
        //CurrentActor.rollDice();
        //回傳 or 交給
    }
    public void findPathList(Map map ,int step)//找到所有可以走的路
    {
        scout.reconnoiter(map ,step);
        stepCount = 0;
    }
    public void teleport(Block block)
    {
        location = block.standPoint();
        CurrentActor.teleport(location);
    }
    public void move()//按照scout的Path移動
    {
        move(scout.choicePath[0].location ,scout.choicePath[1].location ,++stepCount);
        if ( stepCount == Constants.STEPTIMES )
        {            
            if ( CurrentBlockIndex != scout.choicePath[1].blockIndex )
            {
                this.EnterDirection = scout.choicePath[1].enterDirection;
                this.CurrentBlockIndex = scout.choicePath[1].blockIndex;
                --scout.totalStep;
            }
            stepCount = 0;
            scout.deleteDot(scout.choicePath[0]);//刪除走過的點
        }
    }

    /*==========private==========*/
    private void move(Vector3 now ,Vector3 next ,int step)
    {
        float x = (next.x - now.x) * step / Constants.STEPTIMES;// * Time.deltaTime;
        float z = (next.z - now.z) * step / Constants.STEPTIMES;// * Time.deltaTime;
        location = new Vector3(now.x + x ,Constants.SEALEVEL ,now.z + z);
        //Debug.Log(location);
        //Debug.Log("next: " + next + "now: " + now);
    }
}
