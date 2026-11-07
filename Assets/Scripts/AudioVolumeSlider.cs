using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeSlider : MonoBehaviour
{
    private const float SilenceDecibels = -80f;
    private const float DecibelFactor = 20f;

    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _mixerParameter;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(HandleValueChanged);

        HandleValueChanged(_slider.value);
    }

    private void HandleValueChanged(float linearValue)
    {
        _mixer.SetFloat(_mixerParameter, LinearToDecibels(linearValue));
    }

    private float LinearToDecibels(float linearValue)
    {
        if (linearValue <= 0f)
            return SilenceDecibels;

        return Mathf.Log10(linearValue) * DecibelFactor;
    }
}
