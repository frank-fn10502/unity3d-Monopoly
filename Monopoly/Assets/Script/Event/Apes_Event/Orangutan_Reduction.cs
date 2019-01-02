using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Orangutan_Reduction : EventBase
{
    public Orangutan_Reduction(string n,bool g,int w, string d) :base(n,g,w,d)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //由於猩猩看不慣凱薩，發生內鬥，使猩猩和平指數下降，且猩猩人口減少4%
        group.Resource.civilian -= Convert.ToInt32(group.Resource.civilian*0.04);
        group.Attributes.peace -= 20;
        State = group.State;
    }
}