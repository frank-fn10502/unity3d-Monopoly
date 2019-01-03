using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Virus_Reduction : EventBase
    {
        public Virus_Reduction(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //人類發現新型解藥，使得所有人解藥研發程度提升5%
            for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.antidote += 5;
            }
            State = group.State;
    }
    }
