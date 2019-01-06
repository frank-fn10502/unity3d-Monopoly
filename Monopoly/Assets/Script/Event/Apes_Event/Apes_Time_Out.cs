using System.Collections.Generic;

class Apes_Time_Out : EventBase
{
    public Apes_Time_Out(string n,bool g,int w, string d, string p) :base(n,g,w,d,p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //由於猩猩被人類抓走成為俘虜，猩猩暫停一回合
        group.InJailTime += 1;
        this.Short_detail = group + "暫停一回合";
        group.State = PlayerState.InJail;
    }
}