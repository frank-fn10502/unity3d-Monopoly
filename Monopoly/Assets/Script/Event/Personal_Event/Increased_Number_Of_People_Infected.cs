using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Increased_Number_Of_People_Infected: EventBase
{ 
        public Increased_Number_Of_People_Infected(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //軍營中發現帶有病毒猩猩的屍體，使軍隊人口感染人數增加，軍隊減少10%
            group.Resource.army -= Convert.ToInt32(group.Resource.army * 0.1);
            State = group.State;
        }
}
