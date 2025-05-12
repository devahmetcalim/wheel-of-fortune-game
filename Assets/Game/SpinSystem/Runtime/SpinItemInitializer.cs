using UnityEngine;
using System.Collections.Generic;
using Game.SpinSystem.Data;
using Game.SpinSystem.UI;

namespace Game.SpinSystem.Runtime
{
    public class SpinItemInitializer : MonoBehaviour
    {
        [SerializeField]
        private List<SpinItemUI> activeItems = new ();
        
        public void SetItems(SpinWheelConfig spinConfig)
        {
            List<SpinItemData> iSpinItemDatas = new List<SpinItemData>();
            for (var i = 0; i < activeItems.Count; i++)
            {
                SpinItemData selectedData;
                if (spinConfig.VisualConfig.spinType == SpinType.Bronze)
                    selectedData = i == 0 ? spinConfig.GetBomb() : SetRandomItem(spinConfig, iSpinItemDatas);
                else
                    selectedData = SetRandomItem(spinConfig, iSpinItemDatas);
                
                iSpinItemDatas.Add(selectedData);
                activeItems[i].Setup(selectedData);
            }
        }

        private static SpinItemData SetRandomItem(SpinWheelConfig spinConfig, List<SpinItemData> iSpinItemDatas)
        {
            SpinItemData selectedData;
            do
            {
                selectedData = spinConfig.GetRandomItem();
            } while (iSpinItemDatas.Contains(selectedData));

            return selectedData;
        }
    }
}