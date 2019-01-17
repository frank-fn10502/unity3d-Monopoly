using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Everyone_People_Decrease : EventBase
{
    int subvar = 100;
    public Everyone_People_Decrease(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public Everyone_People_Decrease(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        subvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //所有人類遭遇野生猩猩發動攻擊，失去人口數量
        for (int i = 0;i< droup_list.Count; i++)
        {
            droup_list[i].Resource.civilian -= subvar;
        }
        this.Short_detail = "所有玩家減少人口" + subvar.ToString();
    State = group.State;
    }
}