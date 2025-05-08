using Game.SpinSystem.Data;

namespace Game.Systems.Event
{
    public class RewardCollectedEvent
    {
        public SpinItemData item;
        public RewardCollectedEvent(SpinItemData item) => this.item = item;
    }
}