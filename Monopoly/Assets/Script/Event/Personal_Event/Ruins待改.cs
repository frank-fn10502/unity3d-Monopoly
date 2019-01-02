using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Ruins : EventBase
{ 
        public Ruins (string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於迷失方向前往廢墟
            //group.
            State = group.State;
        }
}
