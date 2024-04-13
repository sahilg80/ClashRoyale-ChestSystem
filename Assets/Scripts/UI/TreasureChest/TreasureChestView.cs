using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestView : MonoBehaviour
    {
        [SerializeField]
        private GameObject treasureChestHolder;
        [SerializeField]
        private TextMeshProUGUI statusText;
        [SerializeField]
        private TextMeshProUGUI timerText;
        [SerializeField]
        private TextMeshProUGUI rewardsRequiredToUnlock;
        [SerializeField]
        private Image rewardsIcon;
        [SerializeField]
        private Animator animatorTreasureChest;

        private void OnEnable()
        {
            
        }
    }
}
