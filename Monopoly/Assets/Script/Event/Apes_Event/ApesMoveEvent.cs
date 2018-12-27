using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class ApesMoveEvent : EventBase
    {
        public ApesMoveEvent(string n,bool g,int w):base(n,g,w)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //猩猩隨機移動
        }
    }