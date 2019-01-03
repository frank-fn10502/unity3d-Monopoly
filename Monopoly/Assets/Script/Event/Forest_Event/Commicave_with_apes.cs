using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Commicave_With_Apes : EventBase
    {
        public Commicave_With_Apes(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於和猩猩談判成功，使外交指數上升
            group.Attributes.diplomatic += 8;
            State = group.State;
    }
    }
