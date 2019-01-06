using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Change_Plant: EventBase
    {
        public Change_Plant(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            Random rand = new Random();
            int p1 = rand.Next(4);
            int p2 = rand.Next(4);
            while(p1 == p2)
            {
                p2 = rand.Next(4);
            }
            int temp = droup_list[p1].CurrentBlockIndex;
            droup_list[p1].teleport(droup_list[p2].CurrentBlockIndex);
            droup_list[p2].teleport(temp);
            this.Short_detail = droup_list[p1].name + "和"+ droup_list[p2].name + "交換位置";
            State = group.State;
        }
    }
