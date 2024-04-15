using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Event
{
    public class EventService
    {
        public EventController OnPlayerUIInitialized { get; private set; }
        public EventController OnClickCollectChestButton { get; private set; }
        public EventController<string> NotifyPanelOpen { get; private set; }
        public EventService()
        {
            OnPlayerUIInitialized = new EventController();
            OnClickCollectChestButton = new EventController();
            NotifyPanelOpen = new EventController<string>();
        }
    }
}
