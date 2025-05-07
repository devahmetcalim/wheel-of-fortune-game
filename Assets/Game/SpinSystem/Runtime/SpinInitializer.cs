
using UnityEngine;
using Game.SpinSystem.UI;

namespace Game.SpinSystem.Runtime
{
    public class SpinInitializer : MonoBehaviour
    {
        [SerializeField] private SpinItemInitializer itemInitializer;
        [SerializeField] private SpinVisualManager visualManager;
        [SerializeField] private SpinWheelConfig bronzeConfig;
        [SerializeField] private SpinWheelConfig silverConfig;
        [SerializeField] private SpinWheelConfig goldConfig;

        private void OnEnable()
        {
            SpinZoneManager.Instance.OnZoneChanged += OnZoneChanged;
        }

        private void OnDisable()
        {
            SpinZoneManager.Instance.OnZoneChanged -= OnZoneChanged;
        }

        private void OnZoneChanged(SpinType spinType, int zone)
        {
            var config = GetConfigForType(spinType);
            itemInitializer.SetItems(config);
            visualManager.ApplyVisual(GetConfigForType(spinType).VisualConfig);
        }

        private SpinWheelConfig GetConfigForType(SpinType type)
        {
            return type switch
            {
                SpinType.Gold => goldConfig,
                SpinType.Silver => silverConfig,
                _ => bronzeConfig
            };
        }
    }
}