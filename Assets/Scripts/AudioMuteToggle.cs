using UnityEngine;
using UnityEngine.UI;

public class AudioMuteToggle : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private float _volumeBeforeMute = 1f;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(HandleValueChanged);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(HandleValueChanged);
    }

    private void HandleValueChanged(bool isOn)
    {
        ApplyMuteState(isOn);
    }

    private void ApplyMuteState(bool isMuted)
    {
        if (isMuted)
        {
            if (AudioListener.volume > 0f)
                _volumeBeforeMute = AudioListener.volume;

            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = _volumeBeforeMute;
        }
    }
}
