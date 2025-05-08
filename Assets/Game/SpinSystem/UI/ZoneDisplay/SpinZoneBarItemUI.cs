using Game.SpinSystem.Config;
using TMPro;
using UnityEngine;

namespace Game.SpinSystem.UI
{   
    public class SpinZoneBarItemUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text zoneText;

        public void SetZone(int zoneNumber, bool isCurrent)
        {
            zoneText.text = zoneNumber.ToString();
            if (isCurrent)
            {
                zoneText.color = SpinConfigRegistry.Instance.GetConfigByZone(zoneNumber).VisualConfig
                    .DisplayHighlightedColor;
            }
            else
            {
                zoneText.color = SpinConfigRegistry.Instance.GetConfigByZone(zoneNumber).VisualConfig
                    .DisplayNormalColor;
            }
        }
    }
    
}