using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class EveryoneGetResourceEvent : EventBase
{
        int addvar = 10;
        public EveryoneGetResourceEvent(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public EveryoneGetResourceEvent(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
        {
            addvar = v;
        }
    public override void DoEvent(List<Group> droup_list, Group group)
        {
            //所有人所得資源增加
            for (int i = 0;i<4;i++)
            {
                droup_list[i].Resource.mineral += Convert.ToInt32(group.Resource.mineral * (addvar/100.0));
            }
            State = group.State;
        }
}
