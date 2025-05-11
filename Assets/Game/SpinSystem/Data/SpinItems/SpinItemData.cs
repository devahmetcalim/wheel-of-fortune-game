using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SpinSystem.Data
{
    public enum SpinItemType { Reward, Bomb }

    [CreateAssetMenu(menuName = "Game/SpinItem")]
    public class SpinItemData : ScriptableObject
    {
        public AssetReferenceAtlasedSprite iconReference;
        public int amount;
        public SpinItemType itemType;
        public string itemKey;
        public int maxAmount;
        public int minAmount;
        public void SetRandomAmount()
        {
            amount = Random.Range(minAmount, maxAmount);
        }

        private void OnValidate()
        {
            if (itemKey.Length > 0 )
            {
                return;
            }
            itemKey = this.name;
        }
    }
}