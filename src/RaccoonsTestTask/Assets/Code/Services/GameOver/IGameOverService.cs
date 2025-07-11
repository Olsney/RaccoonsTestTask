using Code.Gameplay.Cubes;

namespace Code.Services.GameOver
{
    public interface IGameOverService
    {
        void TryFinish(Cube cube);
    }
}