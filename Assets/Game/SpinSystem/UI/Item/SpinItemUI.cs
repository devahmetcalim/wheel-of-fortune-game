using Game.SpinSystem.Data;
using Game.SpinSystem.Utils;
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
        private SpinItemData itemData;
        public SpinItemData GetItemData() => itemData;
        private AsyncOperationHandle<Sprite>? spriteHandle;
        public void Setup(SpinItemData data)
        {
            itemData = data;
            if (data.itemType == SpinItemType.Reward)
            {
                ui_spin_txt_item_xAmount.text = $"x{data.amount}";
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


    }
}