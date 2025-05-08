using System;
using Game.SpinSystem.Data;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Game/SpinWheelConfig")]
public class SpinWheelConfig : ScriptableObject
{
    public SpinItemData[] items;
    public SpinVisualConfig VisualConfig;
    public string key;
    public SpinItemData GetRandomItem()
    {
        return items[Random.Range(0, items.Length)];
    }

    private void OnValidate()
    {
        key = this.name;
    }
}