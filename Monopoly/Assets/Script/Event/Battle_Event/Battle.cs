using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Battle: EventBase
    {
        public Group winer;

    public Battle()
    {
    }

    public Battle(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            Group defender = group;
            for(int i = 0;i<4;i++)
            {
                defender = droup_list[i];
                if (defender.CurrentBlockIndex == group.CurrentBlockIndex && defender != group)
                    break;
            }
            int group_power = caculater_power(group.Attributes.leadership, group.Resource.army);
            int defender_power = caculater_power(defender.Attributes.leadership, defender.Resource.army);
        }
        private int caculater_power(int leadership, int army)
        {
            return Convert.ToInt32( army * ((leadership / 100.0)+1.0));
        }
    }
