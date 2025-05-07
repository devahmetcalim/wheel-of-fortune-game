using System;
using Game.SpinSystem.Data;
public static class SpinEvents
{
    public static event Action OnSpinStarted;
    public static event Action OnSpinCompleted;
    public static event Action<SpinItemData> OnRewardLanded;
    public static event Action OnWalkAwayChosen;

    public static void RaiseSpinStarted() => OnSpinStarted?.Invoke();
    public static void RaiseSpinCompleted() => OnSpinCompleted?.Invoke();
    public static void RaiseRewardLanded(SpinItemData reward) => OnRewardLanded?.Invoke(reward);
    public static void RaiseWalkAway() => OnWalkAwayChosen?.Invoke();
}