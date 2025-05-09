
using System;
using Game.SpinSystem.Config;
using UnityEngine;
using Game.SpinSystem.UI;
using Game.SpinSystem.Utils;
using Game.Systems.Event;
using UnityEngine.AddressableAssets;

namespace Game.SpinSystem.Runtime
{
    public class SpinInitializer : MonoBehaviour
    {
        [SerializeField] private SpinItemInitializer itemInitializer;
        [SerializeField] private SpinVisualManager visualManager;
        private void OnEnable() 
        {
            EventManager.Subscribe<SpinZoneChangedEvent>(OnZoneChanged);
            
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<SpinZoneChangedEvent>(OnZoneChanged);
        }

        private void OnZoneChanged(SpinZoneChangedEvent e)
        {
            var config = SpinConfigRegistry.Instance.GetConfigByZone(e.SpinZone);
            itemInitializer.SetItems(config);
            visualManager.ApplyVisual(SpinConfigRegistry.Instance.GetConfigByZone(e.SpinZone).VisualConfig);
        }

        
    }
}