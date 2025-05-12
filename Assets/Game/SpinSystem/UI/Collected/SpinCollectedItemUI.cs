using Game.SpinSystem.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.Collected
{
    public class SpinCollectedItemUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text amountText;
        private int _amount;
        public void Set(Sprite icon, int setAmount)
        {
            iconImage.sprite = icon;
            Debug.Log("Set Amount" + setAmount);
            amountText.text = NumberFormatter.FormatNumber(setAmount);
        }

        public void UpdateAmount(int addAmount)
        {
            _amount += addAmount;
            Debug.Log("Add amount: " + addAmount);
            Debug.Log("Update Amount" + _amount);
            amountText.text = NumberFormatter.FormatNumber(_amount);
        }
    }
}