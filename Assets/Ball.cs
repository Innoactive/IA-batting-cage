using System;
using UnityEngine;

namespace IAKorolev
{
    public class Ball : MonoBehaviour
    {
        public float CurrentVelocity { get { return body.velocity.magnitude * 3.6f; } }

        public float MaxVelocityAfterHit { get; private set; }

        [SerializeField]
        private Collider batCollider;
        [SerializeField]
        private NearMissDetector nearMissDetector;

        [SerializeField]
        private Rigidbody body;

        private bool isNearMiss = false;

        private bool isHitSomething = false;

        public event Action OnNearMiss;
        public event Action OnBatHit;
        public event Action OnMiss;

        private void Awake()
        {
            nearMissDetector.OnCollision += OnNearMissCollisionEnter;
            MaxVelocityAfterHit = 0f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (isHitSomething)
                return;
            
            if (collision.collider == batCollider)
            {
                OnBatHit();
            }
            else
            {
                if (isNearMiss)
                {
                    OnNearMiss();
                }
                else
                {
                    OnMiss();
                }
            }

            isHitSomething = true;
        }


        private void OnNearMissCollisionEnter(Collision collision)
        {
            isNearMiss = true;
        }

        public void SetVelocity(Vector3 vector)
        {
            body.velocity = vector;
        }

        public void Update()
        {
            if (isHitSomething)
                MaxVelocityAfterHit = Mathf.Max(CurrentVelocity, MaxVelocityAfterHit);
        }
    }
}
