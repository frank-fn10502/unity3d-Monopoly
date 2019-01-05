using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Military_Increase_percent : EventBase
{
        int addvar = 10;
        public Military_Increase_percent(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public Military_Increase_percent(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
        {
            addvar = v;
        }
    public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於個人研發新武器，使軍隊增加10% 
            group.Resource.army += Convert.ToInt32(group.Resource.army * (addvar/100.0));
            State = group.State;
        }
}
