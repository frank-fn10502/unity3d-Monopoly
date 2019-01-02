using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Everyone_People_Decrease : EventBase
{
    public Everyone_People_Decrease(string n,bool g,int w, string d) :base(n,g,w,d)
    {

    }
    public override void DoEvent(List<Group> droup_list, Group group)
    {
        //所有人類遭遇野生猩猩發動攻擊，失去人口數量
        for (int i = 0;i<4;i++)
        {
            droup_list[i].Resource.civilian -=100;
        }
       
        State = group.State;
    }
}