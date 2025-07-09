using Code.Gameplay.Input;

namespace Code.Gameplay.Cube.Spawner
{
    public interface ICubeSpawner
    {
        public void Initialize(PlayerInputHandler playerInputHandler);
    }
}