
using Game.SpinSystem.Config;
using Game.SpinSystem.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.Fail
{
    public class ReviveButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI cost;
        [SerializeField] private Image icon;

        private void OnValidate()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
        }

        private void OnEnable()
        {
            button.interactable = GoldManager.CanPurchase(GameRules.RevivePrice);
            SetColor(button.interactable ? Color.white : Color.gray);
        }

        private void SetColor(Color color)
        {
            title.color = color;
            cost.color = color;
            icon.color = color;
        }
    }

}
