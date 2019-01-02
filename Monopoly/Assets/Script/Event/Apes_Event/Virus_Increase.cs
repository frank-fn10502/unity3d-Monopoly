using System;
using System.Collections.Generic;

class Virus_Increase : EventBase
{
    public Virus_Increase(string n,bool g,int w, string d) :base(n,g,w,d)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //野外遭遇帶著猿流感的猩猩，使得病毒擴散加快，人類死亡3%
        group.Resource.civilian -= Convert.ToInt32(group.Resource.civilian*0.03);
        State = group.State;
    }
}