using System;
using System.Collections.Generic;
using Game.SpinSystem.Data;
using UnityEngine;
using Game.SpinSystem.Infrastructure;
using Game.SpinSystem.Utils;
using Game.Systems.Pooling;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.RewardHistory
{
    public class RewardHistoryPanel : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private RewardHistoryItemUI itemPrefab;
        [SerializeField] private GameObject root;
        [SerializeField] private Button rewardHistoryActivationButton;
        private ObjectPool<RewardHistoryItemUI> itemPool;
        private readonly List<RewardHistoryItemUI> activeItems = new();

        private void Awake()
        {
            itemPool = new ObjectPool<RewardHistoryItemUI>(itemPrefab, 10, container);
        }

        private void OnEnable()
        { 
            var rewards = RewardSaver.Load();
            if (rewards.Count == 0)
            {
                rewardHistoryActivationButton.gameObject.SetActive(false);
                return;
            }
            rewardHistoryActivationButton.onClick.AddListener(Show);
        }

        private void Show()
        {   
            rewardHistoryActivationButton.onClick.RemoveListener(Show);
           
            Clear();
            var rewards = RewardSaver.Load();
            foreach (var reward in rewards)
            {
                var item = itemPool.Get();
                
                item.transform.SetParent(container, false);
                SpinItemData data = Resources.Load<SpinItemData>("SpinItems/" + reward.itemKey);
                AddressableSpriteCache.GetSprite(data.iconReference, sprite =>
                {
                    item.Set(sprite, reward.amount); 
                });
               
                activeItems.Add(item);
            }
            root.SetActive(true);
            rewardHistoryActivationButton.onClick.AddListener(Hide);

        }
        
        private void Hide()
        {
            rewardHistoryActivationButton.onClick.RemoveListener(Hide);
            root.SetActive(false);
            Clear();
            rewardHistoryActivationButton.onClick.AddListener(Show);
        }

        private void Clear()
        {
            foreach (var item in activeItems)
            {
                itemPool.Return(item);
            }
            activeItems.Clear();
        }

        private void OnDisable()
        {
            rewardHistoryActivationButton.onClick.RemoveAllListeners();
        }
    }
}