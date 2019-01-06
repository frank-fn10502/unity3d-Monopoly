using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Apse_Defection : EventBase
    {
        public Apse_Defection(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //猩猩叛逃，所有人類獲得100軍隊，猩猩減少100軍隊
        for (int i = 0; i < droup_list.Count - 1; i++)
            {
                droup_list[i].Resource.army += 100;
            }
            droup_list[droup_list.Count - 1].Resource.army -= 100;
        }
    }
