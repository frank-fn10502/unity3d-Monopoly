using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Diplomatic_Decrease : EventBase
{
        int decrease_var = 10;
        public Diplomatic_Decrease(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public Diplomatic_Decrease(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
        {
            decrease_var = v;
        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //外交減少
            group.Attributes.diplomatic -= decrease_var;
            group.Attributes.diplomatic = (group.Attributes.diplomatic > 0 ? group.Attributes.diplomatic : 0);
            this.Short_detail = group.name + "外交減少:" + decrease_var.ToString();
            State = group.State;
        }
}
