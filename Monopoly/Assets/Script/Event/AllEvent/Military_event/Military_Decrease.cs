using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Military_Decrease : EventBase
    {
        int dead = 20;
        public Military_Decrease(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public Military_Decrease(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
        {
            dead = v;
        }
    public override void DoEvent(List<Group> droup_list, Group group)
        {
            //軍隊減少
            group.Resource.army -= Convert.ToInt32(group.Resource.army*(dead/100.0));
            State = group.State;
        }
    }
