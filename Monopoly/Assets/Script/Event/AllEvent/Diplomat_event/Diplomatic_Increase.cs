using System.Collections.Generic;

class Diplomatic_Increase : EventBase
{
    int addvar = 2;
    public Diplomatic_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public Diplomatic_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //外交指數上升2
        group.Attributes.diplomatic += 2;
        this.Short_detail = group.name + "外交增加:" + addvar.ToString();
        State = group.State;
    }
}