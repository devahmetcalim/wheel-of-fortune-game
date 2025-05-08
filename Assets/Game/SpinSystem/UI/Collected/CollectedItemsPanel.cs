using System;
using System.Collections.Generic;
using UnityEngine;
using Game.SpinSystem.Data;

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

        public void AddOrUpdateItem(SpinItemData data)
        {
            if (itemUIs.ContainsKey(data.itemKey))
            {
                itemUIs[data.itemKey].UpdateAmount(data.amount);
            }
            else
            {
                var go = Instantiate(collectedItemPrefab, contentContainer);
                var ui = go.GetComponent<SpinCollectedItemUI>();
                ui.Set(data.icon, data.amount);
                itemUIs.Add(data.itemKey, ui);
            }
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