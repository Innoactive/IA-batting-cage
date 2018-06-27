using UnityEngine;

namespace IAKorolev
{
    public class BalanceMock : IBalance
    {
        public float BallInitialVelocity
        {
            get
            {
                switch (CurrentDifficulty)
                {
                    case Difficulty.Easy:
                        return 20f;
                    case Difficulty.Medium:
                        return 30f;
                    case Difficulty.Hard:
                        return 40f;
                    default:
                        Debug.LogError("New difficulty is not processed.");
                        return 10f;
                }
            }
        }

        public Difficulty CurrentDifficulty { get; set; }

        public float BallDelay { get { return 5f; } }

        public float BallMissDelayModifier { get { return -1f; } }

        public int MatchDuration { get { return 20; } }
    }
}
