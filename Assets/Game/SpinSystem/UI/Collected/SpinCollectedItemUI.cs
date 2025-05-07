using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.Collected
{
    public class SpinCollectedItemUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text amountText;

        public void Set(Sprite icon, int amount)
        {
            iconImage.sprite = icon;
            amountText.text = amount.ToString();
        }

        public void UpdateAmount(int newAmount)
        {
            amountText.text = newAmount.ToString();
        }
    }
}