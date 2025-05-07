using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Game.SpinSystem.Runtime;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.SpinSystem.UI
{
    public class SpinZoneBarUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RectTransform container;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private ZoneVisualStyle zoneVisualStyle;
        [SerializeField] private TMP_Text currentZoneText;
        [SerializeField] private Image highlightedZoneBgImage;
        [SerializeField] private HighlightedZoneVisualStyle highlightedZoneVisualStyle;

        [Header("Settings")]
        [SerializeField] private int itemCount = 7;
        [SerializeField] private float offsetPerZone = 95f;

        private List<SpinZoneBarItemUI> items = new();

        private void Start()
        {
            CreateZoneItems();
            
            SpinZoneManager.Instance.OnZoneChanged += UpdateUI;
            
         
        }

        private void OnDestroy()
        {
            if (SpinZoneManager.Instance != null)
                SpinZoneManager.Instance.OnZoneChanged -= UpdateUI;
        }

        private void CreateZoneItems()
        {
            for (int i = 0; i < itemCount; i++)
            {
                var itemGO = Instantiate(itemPrefab, container);
                var ui = itemGO.GetComponent<SpinZoneBarItemUI>();
                items.Add(ui);
                
            }
            for (int i = 0; i < items.Count; i++)
            {
                int zone = i + 1;
                items[i].SetZone(zone, i == 0, zoneVisualStyle);
            }
        }

        private void UpdateUI(SpinType type, int currentZone)
        {
            Debug.Log("UpdateUI");
            float duration = 0.25f;
            container.DOAnchorPosX(container.anchoredPosition.x - offsetPerZone, duration).SetEase(Ease.OutCubic);
            currentZoneText.text = $"{currentZone}";

            switch (type)
            {
                case SpinType.Gold:
                    currentZoneText.color = highlightedZoneVisualStyle.superZoneColor;
                    highlightedZoneBgImage.color = zoneVisualStyle.superZoneColor * Color.white;
                    break;
                case SpinType.Silver:
                    currentZoneText.color = highlightedZoneVisualStyle.safeZoneColor;
                    highlightedZoneBgImage.color = zoneVisualStyle.safeZoneColor * Color.white;
                    break;
                default:
                    currentZoneText.color = highlightedZoneVisualStyle.normalColor;
                    highlightedZoneBgImage.color = zoneVisualStyle.normalColor;
                    break;
            }

        }

    }
}