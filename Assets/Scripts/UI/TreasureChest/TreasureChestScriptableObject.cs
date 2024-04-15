
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
        [Tooltip("Timer value should be in minutes.")]
        public float Timer;
        public int CoinsRewardCount { get; private set; }
        public int GemsRewardCount { get; private set; }

        private void OnEnable()
        {
            CoinsRewardCount = Random.Range(MinCoinsRewardCount, MaxCoinsRewardCount);
            GemsRewardCount = Random.Range(MinGemsRewardCount, MaxGemsRewardCount);
        }
    }
}
