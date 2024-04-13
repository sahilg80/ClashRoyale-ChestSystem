using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest
{
    [CreateAssetMenu (fileName = "TreasureChestSO")]
    public class TreasureChestScriptableObject : ScriptableObject
    {
        public float MaxCoinsRewardCount;
        public float MinCoinsRewardCount;
        public float MaxGemsRewardCount;
        public float MinGemsRewardCount;
        public float Timer;
        public float CoinsRewardCount { get; private set; }
        public float GemsRewardCount { get; private set; }

        private void OnEnable()
        {
            CoinsRewardCount = UnityEngine.Random.Range(MinCoinsRewardCount, MaxCoinsRewardCount);
            GemsRewardCount = UnityEngine.Random.Range(MinGemsRewardCount, MaxGemsRewardCount);
        }
    }
}
