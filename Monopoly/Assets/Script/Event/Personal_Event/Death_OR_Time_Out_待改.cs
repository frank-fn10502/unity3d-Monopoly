using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Death_OR_Time_Out: EventBase
{ 
        public Death_OR_Time_Out(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //個人不慎感人猿流感，如回合內沒辦法前進醫院，則死亡亦或者暫停若干回合

            group.Resource.mineral = Convert.ToInt32(group.Resource.mineral * 1.05);
            State = group.State;
        }
}
