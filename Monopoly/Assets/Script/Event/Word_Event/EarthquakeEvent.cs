using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class EarthquakeEvent : EventBase
    {
        public EarthquakeEvent(string n,bool g,int w, string d) :base(n,g,w,d)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //發生地震，所有玩家損失10%人口
            for(int i = 0;i< droup_list.Count;i++)
            {
                droup_list[i].Resource.civilian = Convert.ToInt32(droup_list[i].Resource.civilian*0.9);
            }
        }
    }
