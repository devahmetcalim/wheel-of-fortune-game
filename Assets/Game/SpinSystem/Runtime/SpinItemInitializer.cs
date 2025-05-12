using UnityEngine;
using System.Collections.Generic;
using Game.SpinSystem.Data;
using Game.SpinSystem.Data.Resources.SpinItems;
using Game.SpinSystem.UI;

namespace Game.SpinSystem.Runtime
{
    public class SpinItemInitializer : MonoBehaviour
    {
        [SerializeField]
        private List<SpinItemUI> activeItems = new ();
        private List<SpinItemData> usedItems = new ();
        public void SetItems(SpinWheelConfig spinConfig)
        {
            List<SpinItemInstance> iSpinItemDatas = new List<SpinItemInstance>();
            usedItems.Clear();
            for (var i = 0; i < activeItems.Count; i++)
            {
                SpinItemData selectedData;
                if (spinConfig.VisualConfig.spinType == SpinType.Bronze)
                    selectedData = i == 0 ? spinConfig.GetBomb() : SetRandomItem(spinConfig);
                else
                    selectedData = SetRandomItem(spinConfig);
                
                SpinItemInstance spinItemInstance = new SpinItemInstance(selectedData);
                iSpinItemDatas.Add(spinItemInstance);
                activeItems[i].Setup(spinItemInstance);
            }
        }

        private SpinItemData SetRandomItem(SpinWheelConfig spinConfig)
        {
            SpinItemData selectedData;
            do
            {
                selectedData = spinConfig.GetRandomItem();
            } while (usedItems.Contains(selectedData));
            usedItems.Add(selectedData);
            return selectedData;
        }
    }
}