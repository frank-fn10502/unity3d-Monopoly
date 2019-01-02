using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Increased_Antibody : EventBase
    {
        public Increased_Antibody(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //由於醫院科技技術進步，使得人類對抗病毒抗體增加，人類解藥研發程度上升5%
        for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.antidote += 5;
            }
        }
    }
