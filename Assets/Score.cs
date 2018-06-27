using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IAKorolev
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        private TextMesh text;

        private void Update()
        {
            text.text = string.Format("{0:0} kmph\nScore: {1:0}\nNM:{2} M:{3} T: {4}",
                Core.Instance.Game.MaxVelocityAfterHit,
                Core.Instance.Game.TotalScore,
                Core.Instance.Game.NearMisses,
                Core.Instance.Game.Misses,
                Core.Instance.Game.BallsLaunched);
        }
    }
}
