using System;
using Code.Services.Inputs;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public event Action<Vector2> TapStarted;
        public event Action<Vector2> TapEnded;
        private IInputService _inputService;
        private bool _isDragging;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.IsPointerDown()) 
                TapStarted?.Invoke(_inputService.GetPointerPosition());

            if (_inputService.IsPointerUp() && _isDragging) 
                TapEnded?.Invoke(_inputService.GetPointerPosition());
        }
    }
}