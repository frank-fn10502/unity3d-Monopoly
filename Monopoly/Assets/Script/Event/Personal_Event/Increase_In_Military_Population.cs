using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Increase_In_Military_Population : EventBase
{ 
        public Increase_In_Military_Population(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於個人研發新武器，使軍隊增加10% 
            group.Resource.army += Convert.ToInt32(group.Resource.army * 0.1);
            State = group.State;
        }
}
