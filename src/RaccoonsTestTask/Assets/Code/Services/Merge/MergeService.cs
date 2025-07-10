using Code.Infrastructure.Factory.Game;

namespace Code.Services.Merge
{
    public class MergeService : IMergeService
    {
        private readonly IGameFactory _gameFactory;

        public MergeService(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
    }
}