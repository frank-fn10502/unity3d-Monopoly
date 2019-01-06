using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Secret_Passage_Time_Out : EventBase
{ 
        public Secret_Passage_Time_Out(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //在路途中發現能直達實驗室的秘密通道，但必須暫停2回合
            group.teleport(group.Resource.blockList[0]);
            group.InJailTime += 2;
            group.State = PlayerState.InJail;
            State = group.State;
        }
}
