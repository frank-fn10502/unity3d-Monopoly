using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Discover_Secret_Passage_Forest : EventBase
    {
        private List<int> point;
        public Discover_Secret_Passage_Forest(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {
            point = new List<int>();
            point.Add(196);
            point.Add(533);
            point.Add(821);
            point.Add(455);
        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //由於途中發現祕密通道，可直達森林入口
            Random rand = new Random();
            int rands = rand.Next(point.Count);
            group.teleport(Group.blockList[rands]);
            this.Short_detail = group.name + "直達森林入口";
            State = group.State;
        }
    }
