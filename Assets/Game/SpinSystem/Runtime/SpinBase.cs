using DG.Tweening;
using Game.SpinSystem.Data;
using Game.SpinSystem.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SpinSystem
{
    public class SpinBase : MonoBehaviour, ISpinnable
    {
        [SerializeField] private Transform spinPivot;
        [SerializeField] private Button spinButton;
        [SerializeField] private SpinIndicator indicator;
        private ISpinLogic spinLogic;
        private bool isSpinning;
        private void Awake()
        {
            spinLogic = new SpinLogic();
        }
        private void OnEnable()
        {
            spinButton.onClick.AddListener(Spin);
        }
        public void Spin()
        {
            if (!CanSpin()) return;
            isSpinning = true;
            SpinEvents.RaiseSpinStarted();
            spinButton.interactable = false;
            float angle = spinLogic.CalculateTargetAngle(8);
            spinPivot.DORotate(new Vector3(0, 0, -angle), 4f, RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuart)
                .OnComplete(() =>
                {
                    isSpinning = false;
                    spinButton.interactable = true;
                    if (indicator.GetSelectedItem().itemType == SpinItemType.Bomb)
                    {
                        Debug.Log("Bomb Get");
                        SpinEvents.RaiseBombGet();
                    }
                    else
                    {
                        SpinEvents.RaiseSpinCompleted();
                        SpinEvents.RaiseRewardLanded(indicator.GetSelectedItem());
                        
                    }
                });
        }
        public bool CanSpin()
        {
            return !isSpinning;
        }
        private void OnDisable()
        {
            spinButton.onClick.RemoveListener(Spin);
        }
    }
}
