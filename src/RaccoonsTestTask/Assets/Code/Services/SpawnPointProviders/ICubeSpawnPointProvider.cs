using Code.Gameplay.Cubes;

namespace Code.Services.SpawnPointProviders
{
    public interface ICubeSpawnPointProvider
    {
        CubeSpawnPoint Instance { get; set; }
    }
}