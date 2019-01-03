using System.Collections.Generic;

class Peace_Iindex_Rises : EventBase
{
    public Peace_Iindex_Rises(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //由於猩猩們不自相殘殺，使和平指數上升10
        group.Attributes.peace += 10;
        State = group.State;
    }
}