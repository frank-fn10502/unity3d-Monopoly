using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class EveryoneGetResourceEvent : EventBase
{ 
        public EveryoneGetResourceEvent(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //在礦場中意外發現稀有礦物，個人所得資源增加
        for (int i = 0;i<4;i++)
        {
            droup_list[i].Resource.mineral = Convert.ToInt32(group.Resource.mineral * 1.08);
        }
            
            State = group.State;
        }
}
