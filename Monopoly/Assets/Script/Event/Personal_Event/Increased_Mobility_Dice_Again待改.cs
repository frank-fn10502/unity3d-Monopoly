using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Increased_Mobility_Dice_Again : EventBase
{ 
        public Increased_Mobility_Dice_Again(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //在途中意外發現可用能源，使得移動力增加，並可擲骰子

            group.Resource.mineral = Convert.ToInt32(group.Resource.mineral * 1.05);
            State = group.State;
        }
}
