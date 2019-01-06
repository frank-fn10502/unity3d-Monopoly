using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Lose_Event : EventBase
{
        int addvar = 10;
        public Lose_Event(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
    public override void DoEvent(List<Group> droup_list, Group group)
        {
            //玩家輸
            group.Resource.civilian = 0;
            this.Short_detail = group.name + "輸了";
            State = group.State;
        }
}
