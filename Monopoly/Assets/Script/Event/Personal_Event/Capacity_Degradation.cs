using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Capacity_Degradation: EventBase
{ 
        public Capacity_Degradation(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //人類遭遇猿流感，使得語言能力退化，外交能力喪失，外交減少90%
            group.Attributes.diplomatic = Convert.ToInt32(group.Attributes.diplomatic * 0.1);
            State = group.State;
        }
}
