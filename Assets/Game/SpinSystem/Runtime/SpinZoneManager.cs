using UnityEngine;
using System;
using Game.SpinSystem.Data;
using Game.Systems.Event;

namespace Game.SpinSystem.Runtime
{
    public class SpinZoneManager : MonoBehaviour
    {
        public static SpinZoneManager Instance { get; private set; }
        public event Action<SpinType, int> OnZoneChanged;
        
        [SerializeField] private int currentZone = 1;

        public int CurrentZone => currentZone;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }
        }

        private void Start()
        {
            TriggerZoneUpdate();
        }

        private void OnEnable()
        {
            EventManager.Subscribe<SpinCompletedEvent>(OnSpinCompleted);
        }
        private void OnSpinCompleted(SpinCompletedEvent e)
        {
            TriggerZoneUpdate();
        }

        public SpinType GetSpinTypeForZone(int zone)
        {
            if (zone % 30 == 0) return SpinType.Gold;
            if (zone % 5 == 0) return SpinType.Silver;
            if (zone == 1) return SpinType.Silver;
            return SpinType.Bronze;
        }

        private void TriggerZoneUpdate()
        {
            currentZone++;
            var type = GetSpinTypeForZone(currentZone);
            OnZoneChanged?.Invoke(type, currentZone);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<SpinCompletedEvent>(OnSpinCompleted);
        }
    }
}