using UnityEngine;

namespace Game.SpinSystem.Data
{
    public enum SpinItemType { Reward, Bomb }

    [CreateAssetMenu(menuName = "Game/SpinItem")]
    public class SpinItemData : ScriptableObject
    {
        public Sprite icon;
        public int amount;
        public SpinItemType itemType;
    }
}