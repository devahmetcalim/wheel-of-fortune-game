using UnityEngine;
using System.Collections.Generic;
using Game.SpinSystem.Data;
using Game.SpinSystem.UI;

namespace Game.SpinSystem.Runtime
{
    public class SpinItemInitializer : MonoBehaviour
    {
        [SerializeField]
        private List<SpinItemUI> activeItems = new List<SpinItemUI>();
        

        public void SetItems(SpinWheelConfig spinConfig)
        {
            List<SpinItemData> iSpinItemDatas = new List<SpinItemData>();
            foreach (var item in activeItems)
            {
                
                SpinItemData selecteData;
                do
                {
                    selecteData = spinConfig.GetRandomItem();
                } while (iSpinItemDatas.Contains(selecteData));
                iSpinItemDatas.Add(selecteData);
                item.Setup(selecteData);
            }
        }
    }
}