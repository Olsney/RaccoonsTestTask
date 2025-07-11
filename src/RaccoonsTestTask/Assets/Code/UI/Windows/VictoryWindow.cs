using TMPro;
using UnityEngine;

namespace Code.UI.Windows
{
    public class VictoryWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        protected override void SubscribeUpdates()
        {
            WorldData.Changed += RefreshScoreText;
        }

        protected override void Initialize()
        {
            RefreshScoreText();
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            WorldData.Changed -= RefreshScoreText;
        }

        private void RefreshScoreText() => 
            _text.text = $"You won! Your score is + \n{WorldData.Score.ToString()}";
    }
}