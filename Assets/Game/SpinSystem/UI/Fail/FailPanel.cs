using Game.SpinSystem.Runtime;
using Game.SpinSystem.Runtime.Controllers;
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
        [SerializeField] private Button giveUpButton;
        [SerializeField] private Button reviveButton;
        private void OnEnable()
        {
            EventManager.Subscribe<SpinFailedEvent>(ShowPanel);
            giveUpButton.onClick.AddListener(GiveUpButtonClicked);
            reviveButton.onClick.AddListener(ReviveButtonClicked);
            EventManager.Subscribe<ReviveSpinEvent>(HidePanel);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<SpinFailedEvent>(ShowPanel);
            giveUpButton.onClick.RemoveListener(GiveUpButtonClicked);
            reviveButton.onClick.RemoveListener(ReviveButtonClicked);
            EventManager.Unsubscribe<ReviveSpinEvent>(HidePanel);
        }

        private void ShowPanel(SpinFailedEvent onSpinFailedEvent)
        {
            panelRoot.SetActive(true);
            AddressableSpriteCache.GetSprite(deathSprite, sprite =>
            {
                deathImage.sprite = sprite;
            });
        }

        private void GiveUpButtonClicked()
        {
            panelRoot.SetActive(false);
            EventManager.Publish(new RestartSpinEvent());
        }

        private void ReviveButtonClicked()
        {
            panelRoot.SetActive(false);
            EventManager.Publish(new ReviveSpinEvent());
        }

        private void HidePanel(ReviveSpinEvent e)
        {
            panelRoot.SetActive(false);
        }
    }
}