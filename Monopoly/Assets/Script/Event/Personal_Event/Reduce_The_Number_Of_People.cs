using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Reduce_The_Number_Of_People : EventBase
{ 
        public Reduce_The_Number_Of_People(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //為防止軍隊病毒災情擴散，將處決軍隊受感染人數，軍隊人數減少5%
            group.Resource.army -= Convert.ToInt32(group.Resource.army * 0.05);
            State = group.State;
        }
}
