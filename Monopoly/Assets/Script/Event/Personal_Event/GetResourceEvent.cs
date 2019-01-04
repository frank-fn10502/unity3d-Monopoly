using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class GetResourceEvent : EventBase
{
        int addvar = 10;
        public GetResourceEvent(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public GetResourceEvent(string n, bool g, int w, string d, string p, int v) : base(n, g, w, d, p)
        {
            addvar = v;
        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //所有資源增加5%
            group.Resource.mineral += Convert.ToInt32(group.Resource.mineral * (addvar / 100.0));
            State = group.State;
        }
}
