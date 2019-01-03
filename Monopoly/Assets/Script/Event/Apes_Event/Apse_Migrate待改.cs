using System;
using System.Collections.Generic;


class Apse_Migrate : EventBase
    {
        public Apse_Migrate(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於人類發現猩猩的所在位置，使得猩猩必須遷移
            Random rand = new Random();
            int rands = rand.Next(group.Resource.blockList.Count);
            group.teleport(group.Resource.blockList[rands].Location);
            //group.
            State = group.State;
    }
    }
