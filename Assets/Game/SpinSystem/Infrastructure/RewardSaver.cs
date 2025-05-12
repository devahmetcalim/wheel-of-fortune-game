using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Game.SpinSystem.Data;
using Game.Systems.Event;

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
            var existingRewards = Load();
            var rewardMap = new Dictionary<string, int>();
            foreach (var entry in existingRewards)
            {
                rewardMap[entry.itemKey] = entry.amount;
            }
            foreach (var item in collectedRewards)
            {
                if (item.itemType != SpinItemType.Reward)
                    continue;

                if (rewardMap.ContainsKey(item.itemKey))
                    rewardMap[item.itemKey] += item.amount;
                else
                    rewardMap[item.itemKey] = item.amount;
            }
            var data = new RewardSaveData();
            foreach (var kvp in rewardMap)
            {
                data.rewards.Add(new RewardEntry(kvp.Key, kvp.Value));
            }
            var json = JsonUtility.ToJson(data, true);
            File.WriteAllText(SavePath, json);
            EventManager.Publish(new DataSavedEvent());
        }
        public static void Update(string itemKey, int amount)
        {
            var rewards = Load();
            var existing = rewards.Find(r => r.itemKey == itemKey);
            if (existing != null)
            {
                if (amount == 0)
                    rewards.Remove(existing);
                else
                    existing.amount = amount;
            }
            else
            {
                rewards.Add(new RewardEntry(itemKey, amount));
            }

          

            var data = new RewardSaveData { rewards = rewards };
            var json = JsonUtility.ToJson(data, true);
            File.WriteAllText(SavePath, json);
            EventManager.Publish(new DataSavedEvent());
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