using Code.Gameplay.Cubes;

namespace Code.Services.SpawnPointProviders
{
    public class CubeSpawnPointProvider : ICubeSpawnPointProvider
    {
        public CubeSpawnPoint Instance { get; set; }
    }
}