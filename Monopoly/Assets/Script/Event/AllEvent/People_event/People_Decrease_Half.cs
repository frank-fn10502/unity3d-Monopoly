using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class People_Decrease_Half: EventBase
{ 
        public People_Decrease_Half(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //人口減少一半
            group.Resource.civilian /= 2;
            this.Short_detail = group.name + "人口減少一半";
            State = group.State;
        }
}
