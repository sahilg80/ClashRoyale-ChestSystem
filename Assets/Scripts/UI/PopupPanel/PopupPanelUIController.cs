using Assets.Scripts.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.PopupPanel
{
    public class PopupPanelUIController : IController
    {
        private PopupPanelUIView popupPanelUIView;

        public PopupPanelUIController(PopupPanelUIView popupPanelUIView)
        {
            this.popupPanelUIView = popupPanelUIView;
            Initialize();
        }

        public void Initialize()
        {
            popupPanelUIView.SetController(this);
            SetPanelVisibility(false);
        }

        public void SetPanelVisibility(bool value) => popupPanelUIView.SetPanelVisibility(value);
    }
}
