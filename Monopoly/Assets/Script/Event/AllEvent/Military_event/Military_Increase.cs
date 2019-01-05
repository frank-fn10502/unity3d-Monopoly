using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Military_Increase : EventBase
{
        int addvar = 100;
        public Military_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public Military_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
        {
            addvar = v;
        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //使軍隊增加100 
            group.Resource.army += addvar;
            State = group.State;
        }
}
