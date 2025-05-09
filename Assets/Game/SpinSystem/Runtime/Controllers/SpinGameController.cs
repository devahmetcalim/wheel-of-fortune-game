
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
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<RestartSpinEvent>(OnRestart);
            EventManager.Unsubscribe<ExitSpinEvent>(OnExit);
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
