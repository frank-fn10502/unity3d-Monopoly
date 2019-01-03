using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Lost_Population : EventBase
    {
        public Lost_Population(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //所有人類途中遭遇，野生猩猩發動攻擊，失去人口數量
        for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.civilian = Convert.ToInt32(droup_list[i].Resource.civilian*0.9);
            }
        }
    }
