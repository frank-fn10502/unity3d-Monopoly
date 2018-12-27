using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public abstract class EventBase
    {
        private string name;
        private bool isGood;
        private int weight;
        private string detail;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool IsGood
    {
            get { return isGood; }
            set { isGood = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Detail
    {
            get { return detail; }
            set { detail = value; }
        }
    public EventBase(string n = "", bool g= true ,int w = 1, string d = "")
        {
            name = n;
            isGood = g;
            weight = w;
            detail = d;
        }

        public abstract void DoEvent(List<Group> droup_list, Group group);
    }
