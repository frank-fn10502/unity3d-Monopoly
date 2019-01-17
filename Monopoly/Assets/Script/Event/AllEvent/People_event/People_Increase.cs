using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class People_Increase : EventBase
{
    int addvar = 100;
    public People_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public People_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //使人數增加100
        group.Resource.civilian += addvar;
        this.Short_detail = group.name + "人口增加:" + addvar.ToString();
        State = group.State;
    }
}