using Game.SpinSystem.Utils;
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
            SpinEvents.OnBombGet += ShowPanel;
        }

        private void OnDisable()
        {
            SpinEvents.OnBombGet -= ShowPanel;
        }

        private void ShowPanel()
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