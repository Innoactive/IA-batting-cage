using UnityEngine;

namespace IAKorolev
{
    public class Core : MonoBehaviour
    {
        public static Core Instance { get; private set; }

        public BalanceMock Balance { get; private set; }

        public Game Game { get; private set; }
        
        private void Awake()
        {
            Instance = this;

            Balance = new BalanceMock
            {
                CurrentDifficulty = Difficulty.Easy
            };

            Game = GetComponent<Game>();

            Game.StartMatch();
        }
    }
}
