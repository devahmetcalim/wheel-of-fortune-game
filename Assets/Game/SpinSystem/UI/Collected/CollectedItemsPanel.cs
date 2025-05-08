using System;
using System.Collections.Generic;
using UnityEngine;
using Game.SpinSystem.Data;
using Game.SpinSystem.Utils;

namespace Game.SpinSystem.UI.Collected
{
    public class CollectedItemsPanel : MonoBehaviour
    {
        [SerializeField] private Transform contentContainer;
        [SerializeField] private GameObject collectedItemPrefab;

        private Dictionary<string, SpinCollectedItemUI> itemUIs = new();

        private void OnEnable()
        {
            SpinEvents.OnRewardLanded += SpinEventsOnOnRewardLanded;
        }

        private void SpinEventsOnOnRewardLanded(SpinItemData spinItemData)
        {
            AddOrUpdateItem(spinItemData);
        }

        private void AddOrUpdateItem(SpinItemData data)
        {
           
            if (!itemUIs.ContainsKey(data.itemKey))
            {
                var go = Instantiate(collectedItemPrefab, contentContainer);
                var ui = go.GetComponent<SpinCollectedItemUI>();
                itemUIs.Add(data.itemKey, ui);
                AddressableSpriteCache.GetSprite(data.iconReference, sprite =>
                {
                    ui.Set(sprite, data.amount);
                });
            }
            itemUIs[data.itemKey].UpdateAmount(data.amount);
            
        }

        public void ClearAll()
        {
            foreach (var kv in itemUIs)
            {
                Destroy(kv.Value.gameObject);
            }
            itemUIs.Clear();
        }

        private void OnDisable()
        {
            SpinEvents.OnRewardLanded -= SpinEventsOnOnRewardLanded;
        }
    }
}