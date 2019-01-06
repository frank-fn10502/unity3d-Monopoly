using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPool
{
    private int total_weight;
    private List<EventBase> event_list;
    private System.Random rand;

    public EventPool()
    {
        total_weight = 0;
        event_list = new List<EventBase>();
        rand = new System.Random(DateTime.Now.Millisecond);
    }

    public void AddEvent(EventBase e)
    {
        total_weight += e.Weight;
        event_list.Add(e);
    }


    public void RemoveEvent(int n)
    {
        if (n < event_list.Count)
            total_weight -= event_list[n].Weight;
        event_list.RemoveAt(n);
    }

    public void Clear()
    {
        total_weight = 0;
        event_list.Clear();
    }

    public void SetWeight(int i,int w)
    {
        int temp = event_list[i].Weight + w;

        if(temp >= 0)
        {
            event_list[i].Weight += w;
            total_weight += w;
        }
        else
        {
            total_weight -= event_list[i].Weight;
            event_list[i].Weight = 0;
        }
    }

    public EventBase GetEvent()
    {
        int r = rand.Next(total_weight);
        int w = 0;

        EventBase e = event_list[0];

        for (int i = 1; i < event_list.Count; ++i)
        {
            w += event_list[i - 1].Weight;
            if (w <= r)
            {
                e = event_list[i];
            }
            else
            {
                break;
            }
        }
        return e;
    }
}
