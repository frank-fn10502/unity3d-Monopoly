using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Serious_Virus : EventBase
    {
        public Serious_Virus(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //由於猩猩文明進步，使得病毒擴散嚴重，且領導力提升，人類擲骰子數基數為暫停，偶數則沒事
        for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.civilian = Convert.ToInt32(droup_list[i].Resource.civilian*0.9);
            }
        }
    }
