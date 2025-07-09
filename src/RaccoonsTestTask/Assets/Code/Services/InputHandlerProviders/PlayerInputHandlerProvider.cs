using Code.Gameplay.Input;
using Code.Services.InputHandlerProvider;

namespace Code.Services.InputHandlerProviders
{
    public class PlayerInputHandlerProvider : IPlayerInputHandlerProvider
    {
        private PlayerInputHandler _playerInputHandler;

        public PlayerInputHandler Get() => 
            _playerInputHandler;

        public void Set(PlayerInputHandler playerInputHandler) => 
            _playerInputHandler = playerInputHandler;
    }
}