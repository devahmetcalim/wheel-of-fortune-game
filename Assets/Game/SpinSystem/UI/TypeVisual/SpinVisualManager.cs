using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.SpinSystem.UI
{
    public class SpinVisualManager : MonoBehaviour
    {
        [SerializeField] private Image wheelBaseImage;
        [SerializeField] private Image indicatorImage;
        [SerializeField] private TMP_Text spinTypeText;

        public void ApplyVisual(SpinVisualConfig spinConfig)
        {
            wheelBaseImage.sprite = spinConfig.wheelBaseSprite;
            indicatorImage.sprite = spinConfig.indicatorSprite;
            spinTypeText.text = spinConfig.displayText;
        }

    }
}