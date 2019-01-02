using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Discover_Secret_Passage_Forest : EventBase
    {
        public Discover_Secret_Passage_Forest(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於途中發現祕密通道，可直達森林入口
            Random rand = new Random();
            int rands = rand.Next(5);
            //group.
            State = group.State;
    }
    }
