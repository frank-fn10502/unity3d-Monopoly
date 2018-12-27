using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class EarthquakeEvent : EventBase
    {
        public EarthquakeEvent(string n,bool g,int w):base(n,g,w)
        {

        }
        public override void DoEvent(List<Group> droup_list, Group group)
        {
            //發生地震，所有玩家損失10%人口
        }
    }
