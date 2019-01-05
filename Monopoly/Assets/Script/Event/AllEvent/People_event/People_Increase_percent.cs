using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class People_Increase_percent : EventBase
{
    int addvar = 10;
    public People_Increase_percent(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public People_Increase_percent(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //使人數增加
        group.Resource.civilian += Convert.ToInt32(group.Resource.civilian*(addvar/100.0));
        State = group.State;
    }
}