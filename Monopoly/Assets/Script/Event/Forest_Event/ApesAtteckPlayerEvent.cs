using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class ApesAtteckPlayerEvent : EventBase
    {
        public ApesAtteckPlayerEvent(string n,bool g,int w):base(n,g,w)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //闖入森林，遭受猩猩偷襲，軍隊減少一半
        }
    }
