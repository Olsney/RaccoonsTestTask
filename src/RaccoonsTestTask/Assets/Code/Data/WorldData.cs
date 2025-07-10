using System;

namespace Code.Data
{
    public class WorldData : IWorldData
    {
        public event Action Changed;
        
        public int Score { get; private set; }

        public void AddScore(int score)
        {
            Score += score;
            
            Changed?.Invoke();
        }
    }
}