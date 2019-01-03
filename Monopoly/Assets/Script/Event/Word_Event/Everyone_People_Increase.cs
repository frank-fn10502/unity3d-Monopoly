using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Everyone_People_Increase : EventBase
{
    public Everyone_People_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //敵方陣營人民投靠，使人數增加100
        for(int i = 0;i<4;i++)
        {
            droup_list[i].Resource.civilian +=100;
        }
       
        State = group.State;
    }
}