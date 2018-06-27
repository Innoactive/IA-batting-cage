using System.Linq;
using UnityEngine;

namespace IAKorolev
{
    public class Game : MonoBehaviour
    {
        public float MaxVelocityAfterHit { get { return trackedBall == null || !isBallHit ? 0f : trackedBall.MaxVelocityAfterHit; } }
        public float TotalScore { get { return scores.Sum(s => s); } }
        public int BallsLaunched { get; private set; }
        public int Misses { get; private set; }
        public int NearMisses { get; private set; }

        //I usually make FSM in case like that. But there are only two states.
        public bool IsRunning { get; private set; }

        private Ball trackedBall;


        private float[] scores;

        private bool isBallHit;

        private float lastTimeBallLaunched;

        [SerializeField]
        private BallSpawner ballSpawner;

        public void StartMatch()
        {
            scores = new float[Core.Instance.Balance.MatchDuration];
            BallsLaunched = 0;
            Misses = 0;
            NearMisses = 0;
            lastTimeBallLaunched = Time.time;
            IsRunning = true;
        }

        public void EndMatch()
        {
            IsRunning = false;
        }

        #region MonoBehaviour methods
        private void Awake()
        {
            ballSpawner.OnNewBallLaunched += OnNewBallLaunched;
        }

        private void Update()
        {
            if (!IsRunning)
                return;
            if (isBallHit)
                scores[BallsLaunched - 1] = trackedBall.MaxVelocityAfterHit;
            float nextShotTime = lastTimeBallLaunched + Core.Instance.Balance.BallDelay;
            if (!isBallHit)
                nextShotTime += Core.Instance.Balance.BallMissDelayModifier;

            if (Time.time >= nextShotTime)
            {
                if (BallsLaunched >= Core.Instance.Balance.MatchDuration)
                {
                    EndMatch();
                    return;
                }

                isBallHit = false;
                ballSpawner.Launch();
                lastTimeBallLaunched = Time.time;
                BallsLaunched++;
            }
        }
        #endregion

        private void OnNewBallLaunched(Ball ball)
        {
            if (trackedBall != null)
            {
                trackedBall.OnNearMiss -= OnNearMiss;
                trackedBall.OnMiss -= OnMiss;
                trackedBall.OnBatHit -= OnBatHit;
            }

            trackedBall = ball;
            trackedBall.OnBatHit += OnBatHit;
            trackedBall.OnNearMiss += OnNearMiss;
            trackedBall.OnMiss += OnMiss;
        }

        private void OnBatHit()
        {
            isBallHit = true;
        }

        private void OnMiss()
        {
            Misses++;
            isBallHit = false;
        }

        private void OnNearMiss()
        {
            NearMisses++;
            OnMiss();
        }
    }
}
