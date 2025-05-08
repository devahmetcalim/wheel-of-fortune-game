
using System;
using Game.SpinSystem.Config;
using UnityEngine;
using Game.SpinSystem.UI;
using Game.SpinSystem.Utils;
using UnityEngine.AddressableAssets;

namespace Game.SpinSystem.Runtime
{
    public class SpinInitializer : MonoBehaviour
    {
        [SerializeField] private SpinItemInitializer itemInitializer;
        [SerializeField] private SpinVisualManager visualManager;
        private void OnEnable() 
        {
            SpinZoneManager.Instance.OnZoneChanged += OnZoneChanged;
            
        }

        private void OnDisable()
        {
            SpinZoneManager.Instance.OnZoneChanged -= OnZoneChanged;
        }

        private void OnZoneChanged(int zone)
        {
            var config = SpinConfigRegistry.Instance.GetConfigByZone(zone);
            itemInitializer.SetItems(config);
            visualManager.ApplyVisual(SpinConfigRegistry.Instance.GetConfigByZone(zone).VisualConfig);
        }

        
    }
}