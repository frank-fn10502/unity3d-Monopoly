using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Battle: EventBase
    {
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
                if (defender.CurrentBlockIndex == group.CurrentBlockIndex && !defender.Equals(group))
                    break;
            }
            int group_power = caculater_power(group.Attributes.leadership, group.Resource.army);
            int defender_power = caculater_power(defender.Attributes.leadership, defender.Resource.army);
            int deal = group_power - defender_power;
            group.Resource.army -= caculater_dead(deal, group.Attributes.leadership, group.Resource.army);
            defender.Resource.army -= caculater_dead(deal, defender.Attributes.leadership, defender.Resource.army);
            Winer = group_power > defender_power ? group : defender;
            State = group.State;
            this.Name = "發生爭鬥";
            this.Image = "EventImage/AllEvent";
            this.Detail = group.CurrentActor.Name + "和" + defender.CurrentActor.Name + "發生爭鬥，玩家" + Winer.CurrentActor.Name + "獲勝";
            this.Short_detail = group.name + "和" + defender.name + "發生爭鬥";
    }
        private int caculater_power(int leadership, int army)
        {
            return Convert.ToInt32( army * ((leadership / 100.0)+1.0));
        }
        private int caculater_dead(int deal, int leadership, int army)
        {
            return (deal - (Convert.ToInt32(army * (leadership / 100.0))));
        }
}
