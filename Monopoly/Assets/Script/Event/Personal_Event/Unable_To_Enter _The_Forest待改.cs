using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Unable_To_Enter: EventBase
{ 
        public Unable_To_Enter(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //猩猩巡邏途中發現人類，使得人類無法進入森林
            State = group.State;
        }
}
