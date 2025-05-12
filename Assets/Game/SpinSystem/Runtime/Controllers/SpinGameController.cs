
using Game.SpinSystem.Config;
using Game.SpinSystem.Infrastructure;
using Game.SpinSystem.UI.Collected;
using Game.Systems.Event;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SpinSystem.Runtime.Controllers
{
    public class SpinGameController : MonoBehaviour
    {
        [SerializeField] private CollectedItemsPanel collectedItemsPanel;
        private void OnEnable()
        {
            EventManager.Subscribe<RestartSpinEvent>(OnRestart);
            EventManager.Subscribe<ExitSpinEvent>(OnExit);
            EventManager.Subscribe<ReviveSpinEvent>(OnRevive);
        }

        private void OnRevive(ReviveSpinEvent obj)
        {
            GoldManager.TrySpendGold(GameRules.RevivePrice);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<RestartSpinEvent>(OnRestart);
            EventManager.Unsubscribe<ExitSpinEvent>(OnExit);
            EventManager.Unsubscribe<ReviveSpinEvent>(OnRevive);
        }
        private void OnExit(ExitSpinEvent _)
        {
            RewardSaver.Save(collectedItemsPanel.GetCollectedItems());
            RestartGame();
        }

        private void OnRestart(RestartSpinEvent _)
        {
            RestartGame();          
        }

        private void RestartGame()
        {
            EventManager.ClearAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
