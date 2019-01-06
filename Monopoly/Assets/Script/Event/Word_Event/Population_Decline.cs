using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Population_Decline : EventBase
{
    public Population_Decline(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //醫院由於災情慘重，使得解藥研究降低，且所有人口減少
        for (int i = 0;i<4;i++)
        {
            droup_list[i].Resource.civilian -=100;
            droup_list[i].Resource.antidote -= 10;
        }
        this.Short_detail = "所有玩家解藥降低10，人口減少100";
        State = group.State;
    }
}