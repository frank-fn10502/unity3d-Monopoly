using System.Collections.Generic;

class Leadership_Increase : EventBase
{
    int addvar = 2;
    public Leadership_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public Leadership_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //領導指數上升2
        group.Attributes.leadership += addvar;
        State = group.State;
    }
}