using Assets.Scripts.Interfaces.Controller;
using Assets.Scripts.UI.TreasureChest;
using Assets.Scripts.UI.TreasureChest.CommandPattern;
using Assets.Scripts.UI.TreasureChest.CommandPattern.ConcreteCommand;
using Assets.Scripts.UI.TreasureChest.CommandPattern.Interface;

namespace Assets.Scripts.UI.GamePlayPanel
{
    public class GamePlayPanelController : IController
    {
        private GamePlayPanelView gamePlayPanelView;

        private TreasureChestTrade commandInvoker;
        public GamePlayPanelController(GamePlayPanelView gamePlayPanelView)
        {
            this.gamePlayPanelView = gamePlayPanelView;
            Initialize();
        }

        public void Initialize()
        {
            gamePlayPanelView.SetController(this);
            gamePlayPanelView.SubscribeEvents();
        }

        public void OnClickCollectChestButton()
        {
            GameService.Instance.EventService.OnClickAddChestButton.InvokeEvent();
        }

        public void OnClickUndoButton()
        {
            commandInvoker.UndoCommand();
            gamePlayPanelView.ToggleUndoVisibility(false);
            // disable undo button
        }

        public void BuyTreasureChest(TreasureChestController controller)
        {
            ICommand buyWithGemCommand = new BuyWithGemCommand(controller);
            commandInvoker = new TreasureChestTrade();
            commandInvoker.AddCommand(buyWithGemCommand);
            gamePlayPanelView.ToggleUndoVisibility(true);
            // enable undo button
        }

        public void ResetUndo()
        {
            commandInvoker.ClearCommands();
            gamePlayPanelView.ToggleUndoVisibility(false);
        }
    }
}
