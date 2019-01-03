using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Human_Time_Out : EventBase
    {
        public Human_Time_Out(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //由於被猩猩抓走成為俘虜，暫停一回合
             group.InJailTime += 1;
             State = group.State;
        }
    }
