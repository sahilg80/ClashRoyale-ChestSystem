using Assets.Scripts.Event;
using Assets.Scripts.UI;
using Assets.Scripts.UI.TreasureChest;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [Header("TreasureChest")]
    [SerializeField]
    private TreasureChestView treasureChestView;
    private TreasureChestService treasureChestService;

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
        treasureChestService = new TreasureChestService(treasureChestView);
        eventService = new EventService();
    }


}
