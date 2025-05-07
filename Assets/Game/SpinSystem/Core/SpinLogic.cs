using UnityEngine;
namespace Game.SpinSystem
{
    public class SpinLogic : ISpinLogic
    {

        public float CalculateTargetAngle(int segmentCount)
        {
            int randomSegment = Random.Range(0, segmentCount);
            return 360f * 5 + randomSegment * 45f;
        }
    }

}
