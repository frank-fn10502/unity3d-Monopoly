using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Antibody_Increased : EventBase
{
     int addvar = 10;
     public Antibody_Increased(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
     {

     }
    public Antibody_Increased(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //各人類解藥研發程度上升
        group.Resource.antidote += addvar;
    }
}
