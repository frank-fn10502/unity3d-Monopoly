using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Military_Population_Reduction : EventBase
{ 
        public Military_Population_Reduction(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //營地發生雪崩，個人軍隊人口縮減一半 
            group.Resource.army /=2;
            State = group.State;
        }
}
