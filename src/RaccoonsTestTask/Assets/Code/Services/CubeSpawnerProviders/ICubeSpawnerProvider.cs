using Code.Gameplay.Cube.Spawner;

namespace Code.Services.CubeSpawnerProviders
{
    public interface ICubeSpawnerProvider
    {
        CubeSpawner Instance { get; set; }
    }
}