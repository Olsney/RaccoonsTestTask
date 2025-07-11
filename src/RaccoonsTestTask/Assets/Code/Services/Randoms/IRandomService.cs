namespace Code.Services.Randoms
{
    public interface IRandomService
    {
        int GetRandomPo2Value();
        float Next(float min, float max);
    }
}