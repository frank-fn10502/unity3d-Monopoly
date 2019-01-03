using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Inaccessible_Forest : EventBase
    {
        public Inaccessible_Forest(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //猩猩巡邏途中發現人類，使得人類無法進入森林
        for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.civilian = Convert.ToInt32(droup_list[i].Resource.civilian*0.9);
            }
        }
    }
