using System;
using UnityEngine;

namespace IAKorolev
{
    public class BallSpawner : MonoBehaviour
    {
        public event Action<Ball> OnNewBallLaunched;

        [SerializeField]
        private Ball ballPrefab;
        
        public void Launch()
        {
            Ball ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            ball.gameObject.SetActive(true);
            ball.SetVelocity(transform.rotation * Vector3.forward * Core.Instance.Balance.BallInitialVelocity);
            if (OnNewBallLaunched != null)
                OnNewBallLaunched(ball);
        }
    }
}
