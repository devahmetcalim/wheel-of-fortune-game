using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Game.SpinSystem.Data;

namespace Game.SpinSystem.Infrastructure
{
    public static class RewardSaver
    {
        private static string SavePath => Path.Combine(Application.persistentDataPath, "collected_rewards.json");

        [System.Serializable]
        private class RewardSaveData
        {
            public List<RewardEntry> rewards = new();
        }

        [System.Serializable]
        public class RewardEntry
        {
            public string itemKey;
            public int amount;

            public RewardEntry(string key, int amt)
            {
                itemKey = key;
                amount = amt;
            }
        }

        public static void Save(List<SpinItemData> collectedRewards)
        {
            var data = new RewardSaveData();
            Load();
            foreach (var item in collectedRewards)
            {
                if (item.itemType == SpinItemType.Reward)
                {
                    data.rewards.Add(new RewardEntry(item.itemKey, item.amount));
                }
            }

            var json = JsonUtility.ToJson(data, true);
            Debug.Log(json);
            File.WriteAllText(SavePath, json);
        }

        public static List<RewardEntry> Load()
        {
            if (!File.Exists(SavePath))
                return new List<RewardEntry>();

            var json = File.ReadAllText(SavePath);
            var data = JsonUtility.FromJson<RewardSaveData>(json);
            return data?.rewards ?? new List<RewardEntry>();
        }

        public static void Clear()
        {
            if (File.Exists(SavePath))
                File.Delete(SavePath);
        }
    }
}