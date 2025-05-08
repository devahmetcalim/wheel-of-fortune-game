using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.Collected
{
    public class SpinCollectedItemUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text amountText;
        private int amount;
        public void Set(Sprite icon, int _amount)
        {
            iconImage.sprite = icon;
            amountText.text = _amount.ToString();
        }

        public void UpdateAmount(int addAmount)
        {
            amount += addAmount;
            amountText.text = amount.ToString();
        }
    }
}