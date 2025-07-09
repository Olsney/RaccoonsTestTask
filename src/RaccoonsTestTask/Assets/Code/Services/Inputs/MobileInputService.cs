using UnityEngine;

namespace Code.Services.Inputs
{
    public class MobileInputService : IInputService
    {
        public bool IsPointerDown()
        {
            if (Input.touchCount == 0) 
                return false;
            
            TouchPhase phase = Input.GetTouch(0).phase;
            
            return phase == TouchPhase.Moved || phase == TouchPhase.Stationary;
        }

        public bool IsPointerUp()
        {
            if (Input.touchCount == 0) 
                return false;
            
            return Input.GetTouch(0).phase == TouchPhase.Ended;
        }

        public Vector2 GetPointerPosition()
        {
            return Input.touchCount > 0
                ? Input.GetTouch(0).position
                : Vector2.zero;
        }
    }
}