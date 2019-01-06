using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class People_Decrease_percent : EventBase
{
    int addvar = 10;
    public People_Decrease_percent(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public People_Decrease_percent(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //使人數增加100
        group.Resource.civilian -= Convert.ToInt32(group.Resource.civilian*(addvar/100.0));
        this.Short_detail = group.name + "和平減少:" + Convert.ToInt32(group.Resource.civilian * (addvar / 100.0)).ToString();
        State = group.State;
    }
}