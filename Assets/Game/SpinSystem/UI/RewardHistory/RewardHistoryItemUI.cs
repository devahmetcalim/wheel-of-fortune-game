
using Game.SpinSystem.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.RewardHistory
{
    public class RewardHistoryItemUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI amountTxt;

        public void Set(Sprite sprite, int amount)
        {
            icon.sprite = sprite;
            amountTxt.text = "x" + NumberFormatter.FormatNumber(amount);
        }
    }

}
