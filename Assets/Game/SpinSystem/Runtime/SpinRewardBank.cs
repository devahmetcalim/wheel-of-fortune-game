using System.Collections.Generic;
using UnityEngine;
using Game.SpinSystem.Data;
using Game.SpinSystem.Data.Resources.SpinItems;

namespace Game.SpinSystem.Runtime
{
    public class SpinRewardBank : MonoBehaviour
    {
        private readonly List<SpinItemInstance> collectedRewards = new();

        public IReadOnlyList<SpinItemInstance> CollectedRewards => collectedRewards;

        public void AddReward(SpinItemInstance reward)
        {
            if (reward.itemType == SpinItemType.Bomb)
            {
                Debug.Log("BOMB! All rewards lost.");
                collectedRewards.Clear();
                return;
            }

            collectedRewards.Add(reward);
        }

        public void ResetRewards()
        {
            collectedRewards.Clear();
        }
    }
}