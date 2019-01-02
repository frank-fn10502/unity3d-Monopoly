using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Apse_Migrate : EventBase
    {
        public Apse_Migrate(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //由於人類發現猩猩的所在位置，使得猩猩必須遷移
            Random rand = new Random();
            int rands = rand.Next(5);
            //group.
            State = group.State;
    }
    }
