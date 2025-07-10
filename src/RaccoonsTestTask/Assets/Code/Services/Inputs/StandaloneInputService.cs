using UnityEngine;

namespace Code.Services.Inputs
{
    public class StandaloneInputService : IInputService
    {
        public bool IsPointerDown() =>
            Input.GetMouseButton(0);

        public bool IsPointerUp() =>
            Input.GetMouseButtonUp(0);

        public Vector2 GetPointerPosition() =>
            Input.mousePosition;
    }
}