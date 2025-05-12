using System;
using Game.SpinSystem.Data;
using Game.SpinSystem.Data.Resources.SpinItems;
using Game.SpinSystem.Utils;
using Game.Systems.Event;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.SpinSystem.UI
{
    public class SpinItemUI : MonoBehaviour
    {
        [SerializeField] private Image ui_spin_item_icon;
        [SerializeField] private TMP_Text ui_spin_txt_item_xAmount;
        [SerializeField] private Collider2D collider;
        private SpinItemInstance itemData;
        public SpinItemInstance GetItemData() => itemData;
        private AsyncOperationHandle<Sprite>? spriteHandle;

        private void OnEnable()
        {
            EventManager.Subscribe<SpinCompletedEvent>(SpinCompleted);
            EventManager.Subscribe<SpinStartedEvent>(SpinStarted);
        }

        private void SpinStarted(SpinStartedEvent obj)
        {
            collider.enabled = true;
        }

        private void SpinCompleted(SpinCompletedEvent obj)
        {
            collider.enabled = false;
        }

        public void Setup(SpinItemInstance data)
        {
            itemData = data;
            if (data.itemType == SpinItemType.Reward)
            {
                ui_spin_txt_item_xAmount.text = $"x{NumberFormatter.FormatNumber(data.amount)}";
            }
            else
            {
                ui_spin_txt_item_xAmount.text = $"BOMB!!!";
            }
            AddressableSpriteCache.GetSprite(itemData.iconReference, sprite =>
            {
                ui_spin_item_icon.sprite = sprite;
            });
        }
        private void OnDestroy()
        {
            if (spriteHandle.HasValue)
                Addressables.Release(spriteHandle.Value);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<SpinCompletedEvent>(SpinCompleted);
            EventManager.Unsubscribe<SpinStartedEvent>(SpinStarted);
        }
    }
}