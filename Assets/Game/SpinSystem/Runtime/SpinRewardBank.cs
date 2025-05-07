using System.Collections.Generic;
using UnityEngine;
using Game.SpinSystem.Data;

namespace Game.SpinSystem.Runtime
{
    public class SpinRewardBank : MonoBehaviour
    {
        private readonly List<SpinItemData> collectedRewards = new();

        public IReadOnlyList<SpinItemData> CollectedRewards => collectedRewards;

        public void AddReward(SpinItemData reward)
        {
            if (reward.itemType == SpinItemType.Bomb)
            {
                Debug.Log("BOMB! All rewards lost.");
                collectedRewards.Clear();
                return;
            }

            collectedRewards.Add(reward);
            Debug.Log($"Collected: {reward.name}");
        }

        public void ResetRewards()
        {
            collectedRewards.Clear();
        }
    }
}