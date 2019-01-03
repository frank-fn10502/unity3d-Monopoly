using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Virus_Increase_Antidote : EventBase
{
    public Virus_Increase_Antidote(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //途中發現帶有變種病毒死亡的人類屍體，使解藥研究程度下降5 %
         group.Resource.antidote -= 5;
         State = group.State;
    }
}