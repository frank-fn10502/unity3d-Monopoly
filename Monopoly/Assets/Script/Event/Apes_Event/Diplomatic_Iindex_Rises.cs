using System.Collections.Generic;

class Diplomatic_Iindex_Rises : EventBase
{
    public Diplomatic_Iindex_Rises(string n, bool g, int w, string d, string p) : base(n, g, w, d, p)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //由於猩猩放棄鬥爭，使猩猩外交指數上升
        group.Attributes.diplomatic += 2;
        State = group.State;
    }
}