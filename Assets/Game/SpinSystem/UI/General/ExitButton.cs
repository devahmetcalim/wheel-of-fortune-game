
using Game.SpinSystem.Config;
using Game.SpinSystem.Runtime;
using Game.Systems.Event;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem.UI
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private Button btn;
        private void OnValidate()
        {
            if (btn == null)
                btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(ExitButtonClick);
            EventManager.Subscribe<SpinStartedEvent>(DisableButton);
            EventManager.Subscribe<SpinZoneChangedEvent>(EnableButton);
        }

        private void DisableButton(SpinStartedEvent obj)
        {
            btn.interactable = false;
        }

        private void EnableButton(SpinZoneChangedEvent e)
        {
            if(e.SpinZone == 1) return;
            if (SpinConfigRegistry.Instance.GetTypeByZone(e.SpinZone) == SpinType.Bronze) return;
            btn.interactable = true;
        }

        private void OnDisable()
        {
            btn.onClick.RemoveListener(ExitButtonClick);
            EventManager.Unsubscribe<SpinStartedEvent>(DisableButton);
            EventManager.Unsubscribe<SpinZoneChangedEvent>(EnableButton);
        }

        private void ExitButtonClick()
        {
            EventManager.Publish(new ExitSpinEvent());
        }
    }

}
