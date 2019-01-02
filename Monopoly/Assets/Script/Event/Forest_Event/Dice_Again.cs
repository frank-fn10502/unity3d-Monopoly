using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Dice_Again : EventBase
    {
        public Dice_Again(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //從俘虜中逃出，再次擲骰子
            //State = PlayerState.;
        }
    }
