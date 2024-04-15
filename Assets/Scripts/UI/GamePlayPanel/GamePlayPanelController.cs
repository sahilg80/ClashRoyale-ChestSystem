using Assets.Scripts.Interfaces.Controller;

namespace Assets.Scripts.UI.GamePlayPanel
{
    public class GamePlayPanelController : IController
    {
        private GamePlayPanelView gamePlayPanelView;

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
    }
}
