using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public abstract class EventBase
    {
        private string name;
        private bool isGood;
        private int weight;

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


        public EventBase(string n = "", bool g= true ,int w = 1)
        {
            name = n;
            isGood = g;
            weight = w;
        }

        public abstract void DoEvent();
    }
