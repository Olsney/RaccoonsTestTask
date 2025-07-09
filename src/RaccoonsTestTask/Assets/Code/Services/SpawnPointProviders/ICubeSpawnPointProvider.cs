using Code.Gameplay.Cube;

namespace Code.Services.SpawnPointProviders
{
    public interface ICubeSpawnPointProvider
    {
        CubeSpawnPoint Instance { get; set; }
    }
}