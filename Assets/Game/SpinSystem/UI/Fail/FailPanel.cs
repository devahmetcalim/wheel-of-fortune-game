using UnityEngine;

namespace Game.SpinSystem.UI.Fail
{
    public class FailPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panelRoot;

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
        }

        public void HidePanel()
        {
            panelRoot.SetActive(false);
        }
    }
}