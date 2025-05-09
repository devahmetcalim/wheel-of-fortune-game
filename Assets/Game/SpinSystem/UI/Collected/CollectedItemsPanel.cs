using System;
using System.Collections.Generic;
using UnityEngine;
using Game.SpinSystem.Data;
using Game.SpinSystem.Utils;
using Game.Systems.Event;
using Game.Systems.Pooling;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.Collected
{
    public class CollectedItemsPanel : MonoBehaviour
    {
        [SerializeField] private Transform contentContainer;
        [SerializeField] private SpinCollectedItemUI collectedItemPrefab;
        [SerializeField] private ScrollRect scrollRect;
        private Dictionary<string, SpinCollectedItemUI> itemUIs = new();
        private List<SpinItemData> collectedItems = new();
        private ObjectPool<SpinCollectedItemUI> itemPool;

        private void Awake()
        {
            itemPool = new ObjectPool<SpinCollectedItemUI>(collectedItemPrefab, 10, contentContainer);
        }
        private void OnEnable()
        {
            EventManager.Subscribe<RewardCollectedEvent>(RewardCollected);
        }

        private void RewardCollected(RewardCollectedEvent rewardCollectedEvent)
        {
            AddOrUpdateItem(rewardCollectedEvent.item);
        }

        private void AddOrUpdateItem(SpinItemData data)
        {
           
            if (!itemUIs.ContainsKey(data.itemKey))
            {
                var ui = itemPool.Get();
                itemUIs.Add(data.itemKey, ui);
                scrollRect.enabled = itemUIs.Count > 4;
                AddressableSpriteCache.GetSprite(data.iconReference, sprite =>
                {
                    ui.Set(sprite, data.amount);
                });
            }
            itemUIs[data.itemKey].UpdateAmount(data.amount);
            if (!collectedItems.Contains(data))
            {
                collectedItems.Add(data);
            }
            
        }

        public void ClearAll()
        {
            foreach (var kv in itemUIs)
            {
                itemPool.Return(kv.Value);
            }
            collectedItems.Clear(); 
            itemUIs.Clear();
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<RewardCollectedEvent>(RewardCollected);
        }
        public List<SpinItemData> GetCollectedItems()
        {
            return collectedItems;
        }
    }
}