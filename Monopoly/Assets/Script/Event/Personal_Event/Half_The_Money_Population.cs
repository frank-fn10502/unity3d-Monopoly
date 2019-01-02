using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Half_The_Money_Population : EventBase
{ 
        public Half_The_Money_Population(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於礦場倒塌，口減少一半
            group.Resource.civilian /= 2;
            State = group.State;
        }
}
