using Code.Gameplay.Cubes.Spawner;

namespace Code.Services.CubeSpawnerProviders
{
    public interface ICubeSpawnerProvider
    {
        CubeSpawner Instance { get; set; }
    }
}