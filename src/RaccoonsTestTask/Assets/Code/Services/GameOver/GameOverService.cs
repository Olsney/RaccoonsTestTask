using Code.Gameplay.Cubes;
using Code.UI;
using Code.UI.Factory;
using Code.UI.Services.Windows;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Services.GameOver
{
    public class GameOverService : IGameOverService
    {
        private readonly IWindowService _windowService;
        private const int MaxCubeValue = 131072;

        public GameOverService(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void TryFinish(Cube cube)
        {
            if (cube.Value >= MaxCubeValue)
            {
                _windowService.Open(WindowType.VictoryWindow);
                FinishGame();
            }

            if (cube.IsInGame)
            {
                _windowService.Open(WindowType.LoseWindow);
                FinishGame();
            }
        }

        private static void FinishGame() => 
            Time.timeScale = 0;
    }
}