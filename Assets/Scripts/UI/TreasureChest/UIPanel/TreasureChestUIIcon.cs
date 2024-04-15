
using System;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest.UIPanel
{
    public class TreasureChestUIIcon : MonoBehaviour
    {
        private event Action OnTreasureOpenAnimationFinish;

        public void SubscribeEvents(Action callback) => OnTreasureOpenAnimationFinish += callback;
        public void UnSubscribeEvents(Action callback) => OnTreasureOpenAnimationFinish -= callback;

        // this method will be invoked by the event key frame
        public void TreasureOpenAnimationComplete() => OnTreasureOpenAnimationFinish?.Invoke();
    }
}
