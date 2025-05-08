using System.Collections.Generic;
using UnityEngine;
using Game.SpinSystem.Data;

namespace Game.SpinSystem.Config
{
    public class SpinConfigRegistry : MonoBehaviour
    {
        [System.Serializable]
        public class ConfigPair
        {
            public SpinType type;
            public SpinWheelConfig config;
        }

        public static SpinConfigRegistry Instance { get; private set; }

        [SerializeField] private List<ConfigPair> configs;

        private Dictionary<SpinType, SpinWheelConfig> typeToConfig = new();
        private Dictionary<SpinWheelConfig, SpinType> configToType = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (var pair in configs)
            {
                typeToConfig[pair.type] = pair.config;
                configToType[pair.config] = pair.type;
            }
        }

        public SpinWheelConfig GetConfig(SpinType type)
        {
            return typeToConfig.TryGetValue(type, out var config) ? config : null;
        }

        public SpinType GetType(SpinWheelConfig config)
        {
            return configToType.TryGetValue(config, out var type) ? type : default;
        }
        public SpinType GetTypeByZone(int zone)
        {
            if (zone % 30 == 0) return SpinType.Gold;
            if (zone % 5 == 0) return SpinType.Silver;
            if (zone == 1) return SpinType.Silver;
            return SpinType.Bronze;
        }

        public SpinWheelConfig GetConfigByZone(int zone)
        {
            var type = GetTypeByZone(zone);
            return GetConfig(type);
        }

    }
}