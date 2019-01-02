using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Lack_Of_Energy : EventBase
    {
        public Lack_Of_Energy(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
        //城市人口增加，使得能源不足
            for (int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.mineral /= 2;
            }
            State = group.State;
        }
    }
