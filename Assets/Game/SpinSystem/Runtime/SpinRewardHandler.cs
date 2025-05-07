using UnityEngine;
using Game.SpinSystem.Data;

namespace Game.SpinSystem.Runtime
{
    public class SpinRewardHandler : MonoBehaviour
    {
        [SerializeField] private SpinRewardBank rewardBank;

        private void OnEnable()
        {
            SpinEvents.OnRewardLanded += HandleReward;
        }

        private void OnDisable()
        {
            SpinEvents.OnRewardLanded -= HandleReward;
        }

        private void HandleReward(SpinItemData reward)
        {
            rewardBank.AddReward(reward);
        }
    }
}