using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class People_Increase : EventBase
{
    public People_Increase(string n,bool g,int w, string d) :base(n,g,w,d)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //敵方陣營人民投靠，使人數增加100
        group.Resource.civilian +=100;
        State = group.State;
    }
}