using Game.SpinSystem.Data;
using Game.SpinSystem.Data.Resources.SpinItems;

namespace Game.Systems.Event
{
    public class RewardCollectedEvent
    {
        public SpinItemInstance item;
        public RewardCollectedEvent(SpinItemInstance item) => this.item = item;
    }
}