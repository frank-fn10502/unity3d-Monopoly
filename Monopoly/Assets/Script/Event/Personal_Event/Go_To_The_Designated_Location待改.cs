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
            //途中意外發現軍用直升機，可前往指定地點(軍營、醫院、城市、實驗室)

            group.Resource.mineral = Convert.ToInt32(group.Resource.mineral * 1.05);
            State = group.State;
        }
}
