using System.Collections.Generic;

class Peace_Increase : EventBase
{
    int addvar = 10;
    public Peace_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public Peace_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //和平指數上升10
        group.Attributes.peace += addvar;
        this.Short_detail = group.name + "和平減少:" + addvar.ToString();
        State = group.State;
    }
}