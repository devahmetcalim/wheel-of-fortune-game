using UnityEngine;
using System.Collections.Generic;
using Game.SpinSystem.UI;

namespace Game.SpinSystem.Runtime
{
    public class SpinItemInitializer : MonoBehaviour
    {
        [SerializeField]
        private List<SpinItemUI> activeItems = new List<SpinItemUI>();


        public void SetItems(SpinWheelConfig spinConfig)
        {
            foreach (var item in activeItems)
            {
                item.Setup(spinConfig.GetRandomItem());
            }
        }
    }
}