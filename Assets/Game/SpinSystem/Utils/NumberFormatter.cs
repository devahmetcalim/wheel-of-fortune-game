namespace Game.SpinSystem.Utils
{
    public static class NumberFormatter
    {
        public static string FormatNumber(int number)
        {
            if (number >= 1_000_000_000)
                return (number / 1_000_000_000f).ToString("0.#") + "B";
            else if (number >= 1_000_000)
                return (number / 1_000_000f).ToString("0.#") + "M";
            else if (number >= 1_000)
                return (number / 1_000f).ToString("0.#") + "K";
            else
                return number.ToString();
        }
    }
}