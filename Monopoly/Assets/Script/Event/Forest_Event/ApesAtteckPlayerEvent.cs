using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class ApesAtteckPlayerEvent : EventBase
    {
        public ApesAtteckPlayerEvent(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //闖入森林，遭受猩猩偷襲，軍隊減少一半
            group.Resource.army /= 2;
        }
    }
