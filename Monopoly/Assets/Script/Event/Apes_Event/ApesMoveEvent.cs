using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ApesMoveEvent : EventBase
{
    public ApesMoveEvent(string n,bool g,int w, string d) :base(n,g,w,d)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //猩猩隨機移動
        System.Random rand;
        //group.CurrentActor.run();

    }
}