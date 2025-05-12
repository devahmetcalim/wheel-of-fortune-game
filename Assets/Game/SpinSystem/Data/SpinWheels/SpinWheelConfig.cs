using System.Linq;
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
        SpinItemData selectedData;
        do
        {
            selectedData = items[Random.Range(0, items.Length)];
        } while (selectedData.itemType == SpinItemType.Bomb);
       
        return selectedData;
    }

    public SpinItemData GetBomb()
    {
        return items.FirstOrDefault(t => t.itemType == SpinItemType.Bomb);
    }

    private void OnValidate()
    {
        key = this.name;
    }
}