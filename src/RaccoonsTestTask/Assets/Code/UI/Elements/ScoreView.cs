using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Code.UI.Elements
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        [SerializeField] private float _punchScale = 1.2f;
        [SerializeField] private float _scaleDuration = 0.2f;
        [SerializeField] private float _countDuration = 0.3f;

        private int _currentValue;

        private Tween _countTween;
        private Tween _scaleTween;

        public void SetValue(int newValue)
        {
            _countTween?.Kill();
            _scaleTween?.Kill();

            _countTween = DOTween.To(
                () => _currentValue,
                x => {
                    _currentValue = x;
                    _counter.text = x.ToString();
                },
                newValue,
                _countDuration
            ).SetEase(Ease.OutQuad);

            _scaleTween = _counter.transform
                .DOScale(_punchScale, _scaleDuration)
                .SetEase(Ease.OutBack)
                .OnComplete(() => _counter.transform.DOScale(endValue: 1f, duration: _scaleDuration / 2)
                    .SetEase(Ease.InBack));
        }
    }
}