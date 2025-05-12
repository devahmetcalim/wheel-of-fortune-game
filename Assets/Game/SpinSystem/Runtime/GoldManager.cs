using Game.SpinSystem.Infrastructure;

namespace Game.SpinSystem.Runtime
{
    public static class GoldManager
    {
        private const string GOLD_KEY = "spin_item_icon_gold";

        public static int GetGold()
        {
            var rewards = RewardSaver.Load();
            foreach (var reward in rewards)
            {
                if (reward.itemKey == GOLD_KEY)
                    return reward.amount;
            }
            return 0;
        }

        public static bool CanPurchase(int amount)
        {
            var current = GetGold();
            if (current >= amount)
                return true;
            return false;
        }

        public static void TrySpendGold(int amount)
        {
            var current = GetGold();

            SaveGold(current - amount);
        }

        private static void SaveGold(int newAmount)
        {
            RewardSaver.Update(GOLD_KEY, newAmount);
        }
    }
}