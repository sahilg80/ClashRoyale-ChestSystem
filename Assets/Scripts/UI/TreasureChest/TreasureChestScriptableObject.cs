using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest
{
    [CreateAssetMenu (fileName = "TreasureChestSO", menuName = "ScriptableObjects/TreasureChestSO")]
    public class TreasureChestScriptableObject : ScriptableObject
    {
        public TreasureChestType Type;
        public int MaxCoinsRewardCount;
        public int MinCoinsRewardCount;
        public int MaxGemsRewardCount;
        public int MinGemsRewardCount;
        public float Timer;
        public int CoinsRewardCount { get; private set; }
        public int GemsRewardCount { get; private set; }

        private void OnEnable()
        {
            CoinsRewardCount = UnityEngine.Random.Range(MinCoinsRewardCount, MaxCoinsRewardCount);
            GemsRewardCount = UnityEngine.Random.Range(MinGemsRewardCount, MaxGemsRewardCount);
        }
    }
}
