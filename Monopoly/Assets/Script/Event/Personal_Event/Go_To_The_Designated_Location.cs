using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Go_To_The_Designated_Location: EventBase
{ 
        public Go_To_The_Designated_Location(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //途中意外發現軍用直升機，可前隨機前往自己的其中一個領地

            Random rand = new Random();
            int rands = rand.Next(group.Resource.blockList.Count);
            group.teleport(rands/*group.Resource.blockList[rands].Location*/);
            this.Short_detail = group.name + "移動到" + group.Resource.blockList[rands].Location.ToString();
            State = group.State;
        }
}
