using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DisplayManager
{
    private GlobalManager globalManager;

    public DisplayManager(GlobalManager globalManager)
    {
        this.globalManager = globalManager;
    }

    public void rollingDiceAnimation()
    {
        //呼叫扔骰子

        globalManager.TotalStep = 12;//temp
        globalManager.CurrentPlayer.State = PlayerState.SearchPath;//temp
    }
}

