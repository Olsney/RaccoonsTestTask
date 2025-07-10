using Code.Gameplay.Cubes;
using Code.Infrastructure.Factory.Game;
using Code.Services.GameOver;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class GameOverPoint : MonoBehaviour
    {
        private IGameOverService _gameOverService;

        [Inject]
        public void Construct(IGameOverService gameOverService)
        {
            _gameOverService = gameOverService;
        }


        public void Finish(Cube cube) => 
            _gameOverService.TryFinish(cube);
    }
}