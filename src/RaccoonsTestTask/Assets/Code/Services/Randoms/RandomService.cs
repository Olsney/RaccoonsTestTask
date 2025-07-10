using Code.Services.Random;

namespace Code.Services.Randoms
{
    public class RandomService : IRandomService
    {
        public int GetRandomPo2Value() =>
            UnityEngine.Random.value < 0.75 
                ? 2 
                : 4;
    }
}