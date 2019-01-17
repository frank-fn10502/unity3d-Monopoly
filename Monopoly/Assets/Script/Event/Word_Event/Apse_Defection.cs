using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Apse_Defection : EventBase
{
    int addvar = 100;
    public Apse_Defection(string n ,bool g ,int w ,string d ,string p) : base(n ,g ,w ,d ,p)
    {

    }
    public Apse_Defection(string n ,bool g ,int w ,string d ,string p ,int v) : base(n ,g ,w ,d ,p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list ,Group group)
    {
        //猩猩叛逃，所有人類獲得100軍隊，猩猩減少100軍隊
        for ( int i = 0 ; i < droup_list.Count - 1 ; i++ )
        {
            droup_list[i].Resource.army += addvar;
        }
        this.Short_detail = "所有玩家增加軍隊" + addvar.ToString() + "\n" + droup_list[droup_list.Count - 1].name + "減少軍隊" + addvar.ToString();
        droup_list[droup_list.Count - 1].Resource.army -= addvar;
    }
}
