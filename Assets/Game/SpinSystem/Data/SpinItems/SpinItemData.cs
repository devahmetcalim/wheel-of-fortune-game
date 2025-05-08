using System;
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

        private void OnValidate()
        {
            //temKey = this.name;
        }
    }
}