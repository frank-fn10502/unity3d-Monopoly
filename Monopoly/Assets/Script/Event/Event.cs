using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    private EventPool apes;
    private EventPool forest;
    private EventPool personal;
    private EventPool word;
    private EventPool block;

    public Event()
    {
        Add_Apes_Event();
        Add_Forest_Event();
        Add_Personal_Event();
        Add_Word_Event();

    }

    private void Add_Apes_Event()
    {
        apes.AddEvent(new Diplomatic_Iindex_Rises("猩猩放棄鬥爭", true, 4, "由於猩猩死傷慘重,所以放棄鬥爭，使猩猩外交指數上升"));
        apes.AddEvent(new Peace_Iindex_Rises("猩猩們不自相殘殺", true, 6, "由於猩猩們不自相殘殺，使和平指數上升"));
        apes.AddEvent(new People_Time_Out("人類軍營慘遭猩猩入侵", false, 5, "由於人類軍營慘遭猩猩入侵，導致損失慘重，所有人類暫停一回合"));
        apes.AddEvent(new Apes_Time_Out("猩猩被人類俘虜", false, 5, "由於猩猩被人類抓走成為俘虜，猩猩暫停一回合"));
        apes.AddEvent(new Apes_Time_Out("野外遭遇帶著猿流感的猩猩", false, 5, "野外遭遇帶著猿流感的猩猩，使得病毒擴散加快，人類死亡3%"));
        apes.AddEvent(new Human_Diplomacy("紅毛猩猩教導猩猩族群學習語言", true, 5, "由於紅毛猩猩教導猩猩族群學習語言，使猩猩可以跟人類外交，且減少病毒擴散，使解藥研發進度提升，外交指數上升"));
        apes.AddEvent(new Human_Diplomacy("猩猩看不慣凱薩", false, 2, "由於猩猩看不慣凱薩，發生內鬥，使猩猩和平指數下降，猩猩人口減少4%"));

    }

    private void Add_Forest_Event()
    {
        forest.AddEvent(new ApesAtteckPlayerEvent("遭受猩猩偷襲",false,5, "闖入森林，遭受猩猩偷襲，軍隊減少一半"));
    }

    private void Add_Personal_Event()
    {
        personal.AddEvent(new GetResourceEvent("獲得資源", true, 8, "各種資源增加5%"));
    }

    private void Add_Word_Event()
    {
        word.AddEvent(new EarthquakeEvent("發生地震", false, 6, "發生大地震，所有玩家損失10%人口"));
    }
    private EventBase doEvent(Eventtype eventtype,List<Group> droup_list, Group group)
    {
        EventBase doingevent;
        switch (eventtype)
        {
            case Eventtype.Apes:
                doingevent = apes.GetEvent()/*.DoEvent(droup_list,group)*/;
                break;
            case Eventtype.Forest:
                doingevent = forest.GetEvent()/*.DoEvent(droup_list,group)*/;
                break;
            case Eventtype.Personal:
                doingevent = personal.GetEvent()/*.DoEvent(droup_list,group)*/;
                break;
            case Eventtype.Word:
                doingevent = word.GetEvent()/*.DoEvent(droup_list,group)*/;
                break;
            default:
                doingevent = block.GetEvent();
                break;
        }
        doingevent.DoEvent(droup_list, group);
        return doingevent;
    }
}
