using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;

        public void SetValue(int value) => 
            _counter.text = value.ToString();
    }
}