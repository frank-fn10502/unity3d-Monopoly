using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    private EventPool apes;
    private EventPool forest;
    private EventPool personal;
    private EventPool word;

    public Event()
    {
        Add_Apes_Event();
        Add_Forest_Event();
        Add_Personal_Event();
        Add_Word_Event();

    }

    private void Add_Apes_Event()
    {
        apes.AddEvent(new ApesMoveEvent("猩猩移動",true,10, "猩猩隨機移動"));
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
                doingevent = word.GetEvent();
                break;
        }
        doingevent.DoEvent(droup_list, group);
        return doingevent;
    }
}
