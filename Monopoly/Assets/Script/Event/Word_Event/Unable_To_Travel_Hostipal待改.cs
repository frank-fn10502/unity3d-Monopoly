using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Unable_To_Travel_Hostipal : EventBase
    {
        public Unable_To_Travel_Hostipal(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //病毒災情擴增，使得無法前往醫院
        for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.civilian = Convert.ToInt32(droup_list[i].Resource.civilian*0.9);
            }
        State = group.State;
    }
    }
