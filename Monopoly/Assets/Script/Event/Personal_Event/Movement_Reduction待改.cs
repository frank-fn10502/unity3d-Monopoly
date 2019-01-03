using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Movement_Reduction: EventBase
{ 
        public Movement_Reduction(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於進入廢墟，使得移動減少

            group.Resource.mineral = Convert.ToInt32(group.Resource.mineral * 1.05);
            State = group.State;
        }
}
