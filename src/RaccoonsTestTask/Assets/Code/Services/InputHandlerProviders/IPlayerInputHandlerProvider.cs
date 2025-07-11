using Code.Gameplay.Input;

namespace Code.Services.InputHandlerProviders
{
    public interface IPlayerInputHandlerProvider
    {
        PlayerInputHandler Get();
        void Set(PlayerInputHandler playerInputHandler);
    }
}