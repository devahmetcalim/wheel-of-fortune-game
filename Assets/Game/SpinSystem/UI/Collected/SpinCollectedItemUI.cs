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
        public void Set(Sprite icon, int amount)
        {
            iconImage.sprite = icon;
            amountText.text = amount.ToString();
        }

        public void UpdateAmount(int addAmount)
        {
            Debug.Log("Add Amount " + addAmount + " Current Amount: " + amount);
            amount += addAmount;
            amountText.text = amount.ToString();
        }
    }
}