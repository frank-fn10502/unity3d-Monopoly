using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Attack: EventBase
    {
        public Group winer;

        public Attack()
        {
        }

        public Attack(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            Group defender = ((BuildingBlock)Group.blockList[group.CurrentBlockIndex]).Landlord;
            int group_power = caculater_power(group.Attributes.leadership, group.Resource.army);
            int defender_power = caculater_power(defender.Attributes.leadership, defender.Resource.army);
            int deal = group_power - defender_power;
            group.Resource.army -= (deal - (Convert.ToInt32(group.Resource.army * (group.Attributes.leadership / 100.0))));
            defender.Resource.army -= (deal - (Convert.ToInt32(defender.Resource.army * (defender.Attributes.leadership / 100.0))));
            winer = group_power > defender_power ? group : defender;
            State = group.State;
        }
        private int caculater_power(int leadership, int army)
        {
            return Convert.ToInt32( army * ((leadership / 100.0)+1.0));
        }
    }
