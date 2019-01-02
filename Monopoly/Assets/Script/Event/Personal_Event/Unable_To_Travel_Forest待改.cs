using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Unable_To_Travel_Forest: EventBase
{ 
        public Unable_To_Travel_Forest(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於實驗室遭到猩猩攻擊，所有人類將無法前往森林
            State = group.State;
        }
}
