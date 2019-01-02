using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Secret_Passage_Time_Out : EventBase
{ 
        public Secret_Passage_Time_Out(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //在路途中發現能直達實驗室的秘密通道，但必須暫停
            
            State = group.State;
        }
}
