using DG.Tweening;
using Game.SpinSystem.Data;
using Game.SpinSystem.UI;
using UnityEngine;

namespace Game.SpinSystem.Runtime
{
    public class SpinIndicator : MonoBehaviour
    {
        [SerializeField] private float indicatorKickAngle = 15f;
        [SerializeField] private float kickDuration = 0.1f;

        private bool isAnimating;
        private SpinItemData selectedItem;
        public SpinItemData GetSelectedItem() => selectedItem;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isAnimating) return;
            if (!other.TryGetComponent(out SpinItemUI itemUI)) return;
            
            isAnimating = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.parent.DORotate(new Vector3(0, 0, indicatorKickAngle), kickDuration))
                .Append(transform.parent.DORotate(Vector3.zero, kickDuration))
                .OnComplete(() => isAnimating = false);
            selectedItem = itemUI.GetItemData();
        }
        
    }
}