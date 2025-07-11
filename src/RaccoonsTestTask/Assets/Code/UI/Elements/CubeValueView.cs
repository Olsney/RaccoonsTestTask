using System.Collections.Generic;
using Code.Gameplay.Cubes;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
    public class CubeValueView : MonoBehaviour
    {
        [SerializeField] private Cube _cube;
        [SerializeField] private List<TextMeshPro> _texts = new();
        
        private void Awake()
        {
            _cube.ValueUpdated += UpdateValue;
            
            UpdateValue();
        }

        private void UpdateValue()
        {
            foreach (TextMeshPro text in _texts) 
                text.SetText(_cube.Value.ToString());
        }
    }
}