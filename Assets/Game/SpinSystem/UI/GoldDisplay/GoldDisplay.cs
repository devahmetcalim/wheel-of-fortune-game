using System;
using System.Collections;
using System.Linq;
using Game.SpinSystem.Data;
using Game.SpinSystem.Infrastructure;
using Game.SpinSystem.Runtime;
using Game.SpinSystem.Utils;
using Game.Systems.Event;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.GoldDisplay
{
    public class GoldDisplay : MonoBehaviour
    {
        [SerializeField] private AssetReferenceAtlasedSprite iconReference;
        [SerializeField] private Image cashIconImage;
        [SerializeField] private TextMeshProUGUI cashAmountText;
        private readonly string _goldItemKey = "spin_item_icon_gold";
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(.1f);
            SpinItemData cashItemData = Resources.Load<SpinItemData>("SpinItems/" + _goldItemKey);
            AddressableSpriteCache.GetSprite(cashItemData.iconReference, sprite =>
            {
                cashIconImage.sprite = sprite;
                
            });
            cashAmountText.text = GoldManager.GetGold().ToString();
        }

        private void OnEnable()
        {
            EventManager.Subscribe<DataSavedEvent>(OnDataSaved);
        }

        private void OnDataSaved(DataSavedEvent obj)
        {
            cashAmountText.text = GoldManager.GetGold().ToString();
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<DataSavedEvent>(OnDataSaved);
        }
    }
}
