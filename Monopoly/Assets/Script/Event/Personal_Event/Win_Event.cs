using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Win_Event : EventBase
{
        int addvar = 10;
        public Win_Event(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //玩家直接獲勝
            for(int i = 0;i<5;i++)
            {
                if(!group.Equals(droup_list[i]))
                {
                    droup_list[i].Resource.civilian = 0;
                }
            }
            this.Short_detail = group.name + "獲勝";
            State = group.State;
        }
}
