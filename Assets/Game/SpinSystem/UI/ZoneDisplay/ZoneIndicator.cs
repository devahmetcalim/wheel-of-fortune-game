
using System;
using Game.Systems.Event;
using TMPro;
using UnityEngine;

namespace Game.SpinSystem.UI
{
    public class ZoneIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI superZoneIndicatorTxt;
        [SerializeField] private TextMeshProUGUI safeZoneIndicatorTxt;
        private int _superZoneBaseInterval = 30;
        private int _safeZoneBaseInterval = 5;
        private int _currentSuperZone = 30;
        private int _currentSafeZone = 5;
        private void Awake()
        {
            _currentSuperZone = _superZoneBaseInterval;
            _currentSafeZone = _safeZoneBaseInterval;
            superZoneIndicatorTxt.text = _currentSuperZone.ToString();
            safeZoneIndicatorTxt.text = _currentSafeZone.ToString();
        }

        private void OnEnable()
        {
            EventManager.Subscribe<SpinZoneChangedEvent>(OnSpinZoneChanged);
        }

        private void OnSpinZoneChanged(SpinZoneChangedEvent obj)
        {
            if (obj.SpinZone > 1)
            {
                if (obj.SpinZone % _currentSuperZone == 0)
                {
                    _currentSuperZone += _superZoneBaseInterval;
                    superZoneIndicatorTxt.text = _currentSuperZone.ToString();
                }
                if (obj.SpinZone % _currentSafeZone == 0)
                {
                    _currentSafeZone += _safeZoneBaseInterval;
                    safeZoneIndicatorTxt.text = _currentSafeZone.ToString();
                }
            }
            
        }

        private void OnDisable()
        {
            
            EventManager.Unsubscribe<SpinZoneChangedEvent>(OnSpinZoneChanged);
        }
    }

}
