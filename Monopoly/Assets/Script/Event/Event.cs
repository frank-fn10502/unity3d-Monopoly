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
    private List<int> Event_Weight;

    public Event()
    {
        Add_Apes_Event();
        Add_Forest_Event();
        Add_Personal_Event();
        Add_Word_Event();

    }

    private void Add_Apes_Event()
    {
        //外交
        apes.AddEvent(new Diplomatic_Iindex_Rises("猩猩放棄鬥爭", true, 4, "由於猩猩死傷慘重,所以放棄鬥爭，使猩猩外交指數上升","AllEvent"));//0
        //和平
        apes.AddEvent(new Peace_Iindex_Rises("猩猩們不自相殘殺", true, 6, "由於猩猩們不自相殘殺，使和平指數上升10", "AllEvent"));//1
        apes.AddEvent(new Orangutan_Reduction("猩猩看不慣凱薩", false, 2, "由於猩猩看不慣凱薩，發生內鬥，使猩猩和平指數下降20，猩猩人口減少4%", "AllEvent"));//2
        //領導
        apes.AddEvent(new Virus_Increase("帶著猿流感的猩猩失控爆走", false, 5, "帶著猿流感的猩猩失控爆走，使得病毒擴散加快，人類死亡3%", "AllEvent"));//3
        
        apes.AddEvent(new People_Time_Out("人類軍營慘遭猩猩入侵", false, 5, "由於人類軍營慘遭猩猩入侵，導致損失慘重，所有人類暫停一回合", "AllEvent"));//4
        apes.AddEvent(new Apes_Time_Out("猩猩被人類俘虜", false, 5, "由於猩猩被人類抓走成為俘虜，猩猩暫停一回合", "AllEvent"));//4
        apes.AddEvent(new Human_Diplomacy("紅毛猩猩教導猩猩族群學習語言", true, 5, "由於紅毛猩猩教導猩猩族群學習語言，使猩猩可以跟人類外交，且減少病毒擴散，使解藥研發進度提升，外交指數上升", "AllEvent"));//6
        apes.AddEvent(new Apse_Migrate("人類發現猩猩的所在位置", false, 1, "由於人類發現猩猩的所在位置，使得猩猩必須遷移", "AllEvent"));//7
    }

    private void Add_Forest_Event()
    {
        forest.AddEvent(new ApesAtteckPlayerEvent("遭受猩猩偷襲",false,5, "闖入森林，遭受群居猩猩偷襲，軍隊減少一半","AllEvent"));
        forest.AddEvent(new Commicave_With_Apes("和猩猩談判成功", true, 4, "由於和猩猩談判成功，使外交指數上升", "AllEvent"));
        forest.AddEvent(new Dice_Again("從俘虜中逃出", true, 6, "從俘虜中逃出，再次擲骰子", "AllEvent"));
        forest.AddEvent(new Discover_Secret_Passage_Forest("途中發現祕密通道", false, 5, "由於途中發現祕密通道，可直達森林入口", "AllEvent"));
        forest.AddEvent(new Human_Suspension_Bout("猩猩被人類俘虜", false, 5, "由於軍營慘遭猩猩入侵，導致損失慘重，所有人類暫停一回合 ", "AllEvent"));
        forest.AddEvent(new Human_Time_Out("被猩猩抓走成為俘虜", false, 5, "由於被猩猩抓走成為俘虜，暫停一回合", "AllEvent"));
        forest.AddEvent(new Human_Time_Out("遭遇猩猩攻擊", false, 5, "遭遇猩猩攻擊，暫停一回合", "AllEvent"));
        forest.AddEvent(new Virus_Increase("野外遭遇帶著猿流感的猩猩", false, 5, "野外遭遇帶著猿流感的猩猩，使得病毒擴散加快，人類死亡3%", "AllEvent"));
        forest.AddEvent(new Apse_Migrate("人類發現猩猩的所在位置", true, 1, "由於人類發現猩猩的所在位置，使得猩猩必須遷移", "AllEvent"));
        forest.AddEvent(new Orangutan_Reduction("猩猩看不慣凱薩", true, 2, "由於猩猩看不慣凱薩，發生內鬥，使猩猩和平指數下降，猩猩人口減少4%", "AllEvent"));
    }

    private void Add_Personal_Event()
    {
        personal.AddEvent(new GetResourceEvent("獲得資源", true, 8, "各種資源增加5%", "AllEvent"));
        personal.AddEvent(new EveryoneGetResourceEvent("在礦場中意外發現稀有礦物", true, 8, "在礦場中意外發現稀有礦物，個人所得資源增加8%", "AllEvent"));
        personal.AddEvent(new Fall_Back("不小心迷失前進方向", true, 8, "個人由於不小心迷失前進方向，倒退", "AllEvent"));
        personal.AddEvent(new Secret_Passage_Time_Out("在路途中發現能直達實驗室的秘密通道", true, 8, "在路途中發現能直達實驗室的秘密通道，但必須暫停2回合","AllEvent"));
        personal.AddEvent(new Increase_In_Military_Population("研發出新武器", true, 8, "由於個人研發新武器，使軍隊增加10%", "AllEvent"));
        personal.AddEvent(new Human_Time_Out("受到戰爭流彈波及", true, 8, "個人受到戰爭流彈波及，暫停一回合養傷", "AllEvent"));
        personal.AddEvent(new Military_Population_Reduction("營地發生雪崩", true, 8, "營地發生雪崩，個人軍隊人口縮減一半 ", "AllEvent"));
        personal.AddEvent(new Half_The_Money_Population("礦場倒塌", true, 8, "由於礦場倒塌，口減少一半", "AllEvent"));
        personal.AddEvent(new Human_Time_Out("猩猩發現落單人類", true, 8, "由於猩猩發現落單人類，個人暫停一回合", "AllEvent"));
        personal.AddEvent(new Human_Time_Out("在橋上不慎踩空", true, 8, "由於在橋上不慎踩空，暫停一回合", "AllEvent"));
        personal.AddEvent(new Discover_Secret_Passage_Forest("途中發現祕密通道", false, 5, "由於途中發現祕密通道，可直達森林入口", "AllEvent"));
        personal.AddEvent(new Human_Time_Out("被猩猩抓走成為俘虜", true, 8, "由於被猩猩抓走成為俘虜，暫停 一回合", "AllEvent"));
        personal.AddEvent(new Dice_Again("從俘虜中逃出", true, 6, "從俘虜中逃出，再次擲骰子", "AllEvent"));
        personal.AddEvent(new Increased_Number_Of_People_Infected("軍營中發現帶有病毒猩猩的屍體", true, 6, "軍營中發現帶有病毒猩猩的屍體，使軍隊人口感染人數增加，軍隊減少10%", "AllEvent"));
        personal.AddEvent(new Virus_Increase_Antidote("途中發現帶有變種病毒死亡的人類屍體", true, 6, "途中發現帶有變種病毒死亡的人類屍體，使解藥研究程度下降5%","AllEvent"));
        personal.AddEvent(new Capacity_Degradation("人類遭遇猿流感，使得語言能力退化", true, 6, "人類遭遇猿流感，使得語言能力退化，外交能力喪失，外交減少90%", "AllEvent"));
        personal.AddEvent(new Reduce_The_Number_Of_People("為防止軍隊病毒災情擴散，將處決軍隊受感染人數", true, 6, "為防止軍隊病毒災情擴散，將處決軍隊受感染人數，軍隊人數減少5%", "AllEvent"));
        personal.AddEvent(new People_Increase("敵方陣營人民投靠", true, 6, "敵方陣營人民投靠，使人數增加100", "AllEvent"));
    }

    private void Add_Word_Event()
    {
        word.AddEvent(new EarthquakeEvent("發生地震", false, 6, "發生大地震，所有玩家損失10%人口", "AllEvent"));
        word.AddEvent(new Everyone_Virus_Increase("受到感染的人類失去控制", false, 6, "受到感染的人類失去控制，到處亂跑，使病毒增加快速 ，人類大量感染，所有人類死亡10%", "AllEvent"));
        word.AddEvent(new Increased_Antibody("醫院科技技術進步", true, 6, "由於醫院科技技術進步，使得人類對抗病毒抗體增加，人類解藥研發程度上升5%", "AllEvent"));
        word.AddEvent(new Everyone_People_Increase("途中遭遇沒受感染的人類，使得人口增加", true, 6, "途中遭遇沒受感染的人類", "AllEvent"));
        word.AddEvent(new Population_Decline("醫院由於災情慘重", false, 6, "醫院由於災情慘重，使得解藥研究降低，且所有人口減少", "AllEvent"));
        word.AddEvent(new Lack_Of_Energy("城市人口增加", false, 6, "城市人口增加，使得資源大量減少", "AllEvent"));
        word.AddEvent(new Everyone_People_Decrease("所有人類遭遇野生猩猩發動攻擊，失去人口數量", false, 6, "所有人類遭遇野生猩猩發動攻擊，失去人口數量", "AllEvent"));
        word.AddEvent(new Virus_Reduction("人類發現新型解藥", true, 6, "人類發現新型解藥，使得所有人解藥研發程度提升2%", "AllEvent"));
        word.AddEvent(new Apse_Defection("猩猩叛逃", true, 6, "猩猩叛逃，所有人類獲得100軍隊，猩猩減少100軍隊", "AllEvent"));

    }
    private void Set_Weight(EventPool Ep, Group group)
    {

    }
    private EventBase doEvent(Eventtype eventtype,List<Group> droup_list, Group group)
    {
        EventBase doingevent;
        switch (eventtype)
        {
            case Eventtype.Apes:
                doingevent = apes.GetEvent()/*.DoEvent(droup_list,group)*/;
                apes.SetWeight(0, 4 + System.Convert.ToInt32(group.Attributes.diplomatic * 0.1));
                apes.SetWeight(1, 4 + System.Convert.ToInt32(group.Attributes.peace * 0.1));
                apes.SetWeight(2, 10 - System.Convert.ToInt32(group.Attributes.peace * 0.1));
                apes.SetWeight(3, 10 - System.Convert.ToInt32(group.Attributes.leadership * 0.1));
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
