using UnityEngine;
using System;
using Game.SpinSystem.Data;
using Game.Systems.Event;

namespace Game.SpinSystem.Runtime
{
    public class SpinZoneManager : MonoBehaviour
    {
        
        [SerializeField] private int currentZone = 1;

        public int CurrentZone => currentZone;

        private void Start()
        {
            TriggerZoneUpdate();
        }

        private void OnEnable()
        {
            EventManager.Subscribe<RewardsUpdatedEvent>(RewardsUpdated);
        }
        private void RewardsUpdated(RewardsUpdatedEvent e)
        {
            TriggerZoneUpdate();
        }

        private void TriggerZoneUpdate()
        {
            currentZone++;
            EventManager.Publish(new SpinZoneChangedEvent(currentZone));
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<RewardsUpdatedEvent>(RewardsUpdated);
        }
    }
}