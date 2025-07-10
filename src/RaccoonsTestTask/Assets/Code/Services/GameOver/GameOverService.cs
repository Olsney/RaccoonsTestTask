using Code.Gameplay.Cubes;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Services.GameOver
{
    public class GameOverService : IGameOverService
    {
        private const int MaxCubeValue = 131072;

        public void TryFinish(Cube cube)
        {
            if (cube.Value >= MaxCubeValue)
            {
                Debug.Log("Game over");
                FinishGame();
            }

            if (cube.IsInGame)
            {
                Debug.Log("Game over");
                FinishGame();
            }
        }

        private static void FinishGame() => 
            Time.timeScale = 0;
    }
}