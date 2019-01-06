using System.Collections.Generic;

class Every_People_Time_Out : EventBase
{
    public Every_People_Time_Out(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //由於軍營慘遭猩猩入侵，導致損失慘重，所有人類暫停一回合
        for(int i = 0;i<4;i++)
        {
            droup_list[i].InJailTime += 1;
            droup_list[i].State = PlayerState.InJail;
        }
        this.Short_detail = "所有人暫停一回合";
        State = group.State;
    }
}