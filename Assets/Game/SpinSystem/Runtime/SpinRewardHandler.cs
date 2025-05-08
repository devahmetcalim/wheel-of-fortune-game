using UnityEngine;
using Game.SpinSystem.Data;
using Game.Systems.Event;

namespace Game.SpinSystem.Runtime
{
    public class SpinRewardHandler : MonoBehaviour
    {
        [SerializeField] private SpinRewardBank rewardBank;

        private void OnEnable()
        {
            EventManager.Subscribe<RewardCollectedEvent>(HandleReward);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<RewardCollectedEvent>(HandleReward);
        }

        private void HandleReward(RewardCollectedEvent rewardCollectedEvent)
        {
            rewardBank.AddReward(rewardCollectedEvent.item);
        }
    }
}