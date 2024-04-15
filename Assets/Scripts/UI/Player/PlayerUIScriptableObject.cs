using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Player
{
    [CreateAssetMenu (fileName ="PlayerUISO", menuName = "ScriptableObjects/PlayerUISO")]
    public class PlayerUIScriptableObject : ScriptableObject
    {
        public int InitialCoinsOwned;
        public int InitialGemsOwned;
        public int ChestSlotsCount;
    }
}
