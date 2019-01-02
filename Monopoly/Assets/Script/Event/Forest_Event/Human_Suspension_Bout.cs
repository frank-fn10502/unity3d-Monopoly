using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Human_Suspension_Bout : EventBase
    {
        public Human_Suspension_Bout(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於軍營慘遭猩猩入侵，導致損失慘重，所有人類暫停回合 
            for(int i = 0;i<4;i++)
            {
                //droup_list[i].
            }
            State = group.State;
        }
    }
