using Code.Gameplay.Input;

namespace Code.Services.InputHandlerProvider
{
    public interface IPlayerInputHandlerProvider
    {
        PlayerInputHandler Get();
        void Set(PlayerInputHandler playerInputHandler);
    }
}