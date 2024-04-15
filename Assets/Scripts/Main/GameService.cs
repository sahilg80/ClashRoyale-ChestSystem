using Assets.Scripts.Event;
using Assets.Scripts.UI;
using Assets.Scripts.Utilities;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{

    [Header("UI Service")]
    [SerializeField] 
    private UIService uiService;
    public UIService UIService => uiService;

    private EventService eventService;
    public EventService EventService => eventService;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private void Initialize()
    {
        eventService = new EventService();
        uiService.Initialize();
    }

}
