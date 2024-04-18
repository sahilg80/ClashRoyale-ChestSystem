using Assets.Scripts.UI.TreasureChest.CommandPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.TreasureChest.CommandPattern.ConcreteCommand
{
    public class BuyWithGemCommand : ICommand
    {
        private TreasureChestController treasureChestController;
        public BuyWithGemCommand(TreasureChestController treasureChestController)
        {
            this.treasureChestController = treasureChestController;
        }

        public void Execute()
        {
            treasureChestController.OnClickBuyWithGemsButton();
        }

        public void Undo()
        {
            treasureChestController.UndoBuyingDecision();
        }
    }
}
