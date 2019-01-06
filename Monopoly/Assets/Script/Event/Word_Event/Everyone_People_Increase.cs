using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Everyone_People_Increase : EventBase
{
    int addvar = 100;
    public Everyone_People_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }

    public Everyone_People_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //敵方陣營人民投靠，使人數增加100
        for(int i = 0;i< droup_list.Count; i++)
        {
            droup_list[i].Resource.civilian += addvar;
        }
        this.Short_detail = "所有玩家增加人口" + addvar.ToString();
        State = group.State;
    }
}