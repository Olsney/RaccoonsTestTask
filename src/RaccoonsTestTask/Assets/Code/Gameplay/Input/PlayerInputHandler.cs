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
        
        public Vector2 PointerPosition() => _inputService.GetPointerPosition();

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.IsPointerDown())
            {
                if (!_isDragging)
                {
                    _isDragging = true;

                    TapStarted?.Invoke(_inputService.GetPointerPosition());
                }
            }
            else
            {
                if (_isDragging && _inputService.IsPointerUp())
                {
                    TapEnded?.Invoke(_inputService.GetPointerPosition());

                    _isDragging = false;
                }
            }
        }
    }
}