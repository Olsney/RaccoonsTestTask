using Code.Gameplay.Cube.Spawner;

namespace Code.Services.CubeSpawnerProviders
{
    public class CubeSpawnerProvider : ICubeSpawnerProvider
    {
        public CubeSpawner Instance { get; set; }
    }
}