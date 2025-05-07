using TMPro;
using UnityEngine;

namespace Game.SpinSystem.UI
{   
    public class SpinZoneBarItemUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text zoneText;

        public void SetZone(int zoneNumber, bool isCurrent, ZoneVisualStyle style)
        {
            zoneText.text = zoneNumber.ToString();

            if (zoneNumber % 30 == 0)
                zoneText.color = style.superZoneColor;
            else if (zoneNumber % 5 == 0)
                zoneText.color = style.safeZoneColor;
            else if (zoneNumber == 1)
                zoneText.color = style.safeZoneColor;
            else
                zoneText.color = style.normalColor;
        }
    }
    
}