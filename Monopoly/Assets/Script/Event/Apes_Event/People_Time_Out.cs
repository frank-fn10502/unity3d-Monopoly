using System.Collections.Generic;

class People_Time_Out : EventBase
{
    public People_Time_Out(string n,bool g,int w, string d) :base(n,g,w,d)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //由於軍營慘遭猩猩入侵，導致損失慘重，所有人類暫停一回合
        for(int i = 0;i<4;i++)
        {
            //droup_list[i].Attributes += 1;
        }
        State = group.State;
    }
}