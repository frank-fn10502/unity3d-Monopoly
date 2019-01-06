using System.Collections.Generic;

class Everyone_eace_Increase : EventBase
{
    int addvar = 10;
    public Everyone_eace_Increase(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public Everyone_eace_Increase(string n, bool g, int w, string d, string p,int v) : base(n, g, w, d, p)
    {
        addvar = v;
    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //和平指數上升
        for(int i = 0;i<5;i++)
        {
            droup_list[i].Attributes.peace += addvar;
        }
        this.Short_detail = "所有玩家增加和平" + addvar.ToString();
        State = group.State;
    }
}