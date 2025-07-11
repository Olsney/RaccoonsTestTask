namespace Code.Services.Randoms
{
    public class RandomService : IRandomService
    {
        public int GetRandomPo2Value() =>
            UnityEngine.Random.value < 0.75 
                ? 2 
                : 4;
        
        public float Next(float min, float max) =>
            UnityEngine.Random.Range(min, max);
    }
}