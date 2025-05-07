using Game.SpinSystem.Data;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/SpinWheelConfig")]
public class SpinWheelConfig : ScriptableObject
{
    public SpinItemData[] items;
    public SpinVisualConfig VisualConfig;

    public SpinItemData GetRandomItem()
    {
        return items[Random.Range(0, items.Length)];
    }
}