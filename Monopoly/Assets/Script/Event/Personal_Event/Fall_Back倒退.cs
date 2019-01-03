using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Fall_Back : EventBase
    {
        public Fall_Back(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //個人由於不小心迷失前進方向，倒退 
            //group.
            State = group.State;
        }
    }
