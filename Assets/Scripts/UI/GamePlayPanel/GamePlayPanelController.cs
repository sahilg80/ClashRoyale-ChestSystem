using Assets.Scripts.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
            GameService.Instance.EventService.OnClickCollectChestButton.InvokeEvent();
        } 
    }
}
