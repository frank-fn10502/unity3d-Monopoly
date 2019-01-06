using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Everyone_Virus_Increase : EventBase
{
    int subvar = 10;
    public Everyone_Virus_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public Everyone_Virus_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        subvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //受到感染的人類失去控制，到處亂跑，使病毒增加快速 ，人類大量感染，所有人類死亡10%
        for(int i = 0;i< droup_list.Count; i++)
        {
            group.Resource.civilian -= Convert.ToInt32(group.Resource.civilian*0.1);
        }
        this.Short_detail = "所有玩家人口減少" + subvar.ToString()+"%";
        State = group.State;
    }
}