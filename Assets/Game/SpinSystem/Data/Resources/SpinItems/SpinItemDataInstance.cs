using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SpinSystem.Data.Resources.SpinItems
{
    public class SpinItemInstance
    {
        public SpinItemType itemType;
        public string itemKey;
        public AssetReferenceAtlasedSprite iconReference;
        public int amount;

        public SpinItemInstance(SpinItemData data)
        {
            itemType = data.itemType;
            itemKey = data.itemKey;
            iconReference = data.iconReference;
            amount = Random.Range(data.minAmount, data.maxAmount + 1);
        }
    }
}
