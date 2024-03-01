using UnityEngine;
using UnityEngine.UI;

namespace DreamHub.Aberration
{
    public sealed class AberrationSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void Start()
        {
            AberrationLevel.OnUpdated += SetValue;
            _slider.maxValue = 100f;
        }

        private void SetValue(float percent)
        {
            _slider.value = percent;
        }

        private void OnDisable()
        {
            AberrationLevel.OnUpdated -= SetValue;
        }
    }
}
