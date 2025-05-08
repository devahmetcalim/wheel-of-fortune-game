using Game.SpinSystem.Utils;
using Game.Systems.Event;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Game.SpinSystem.UI.Fail
{
    public class FailPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panelRoot;
        [SerializeField] private AssetReferenceAtlasedSprite deathSprite;
        [SerializeField] private Image deathImage;
        private void OnEnable()
        {
            EventManager.Subscribe<SpinFailedEvent>(ShowPanel);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<SpinFailedEvent>(ShowPanel);
        }

        private void ShowPanel(SpinFailedEvent onSpinFailedEvent)
        {
            panelRoot.SetActive(true);
            AddressableSpriteCache.GetSprite(deathSprite, sprite =>
            {
                deathImage.sprite = sprite;
            });
        }

        public void HidePanel()
        {
            panelRoot.SetActive(false);
        }
    }
}