using Game.SpinSystem.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.SpinSystem.UI
{
    public class SpinItemUI : MonoBehaviour
    {
        [SerializeField] private Image ui_spin_item_icon;
        [SerializeField] private TMP_Text ui_spin_txt_item_xAmount;
        private SpinItemData itemData;
        public SpinItemData GetItemData() => itemData;
        public void Setup(SpinItemData data)
        {
            ui_spin_item_icon.sprite = data.icon;
            ui_spin_txt_item_xAmount.text = $"x{data.amount}";
            itemData = data;
        }

    }
}