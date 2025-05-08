using UnityEngine;
using System;
using Game.SpinSystem.Data;
using Game.Systems.Event;

namespace Game.SpinSystem.Runtime
{
    public class SpinZoneManager : MonoBehaviour
    {
        public static SpinZoneManager Instance { get; private set; }
        public event Action<int> OnZoneChanged;
        
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

        private void TriggerZoneUpdate()
        {
            currentZone++;
            OnZoneChanged?.Invoke(currentZone);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<SpinCompletedEvent>(OnSpinCompleted);
        }
    }
}