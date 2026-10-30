using UnityEngine;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    private const string MasterParam = "MasterVolume";
    private const string MusicParam = "MusicVolume";
    private const string UIParam = "UIVolume";

    private const int MinVolume = -80;
    private const int VolumeParam = 20;

    [SerializeField] private AudioMixer _mixer;

    public void ToggleMasterVolume(bool activated)
    {
        if (activated)
        {
            _mixer.SetFloat(MasterParam, MinVolume);
        }
        else
        {
            _mixer.SetFloat(MasterParam, 0);
        }
    }

    public void OnMasterChanged(float value)
    {
        SetVolume(MasterParam, value);
    }

    public void OnMusicChanged(float value)
    {
        SetVolume(MusicParam, value);
    }

    public void OnUIChanged(float value)
    {
        SetVolume(UIParam, value);
    }

    private void SetVolume(string mixer, float volume)
    {
        _mixer.SetFloat(mixer, Mathf.Log10(volume) * VolumeParam);
    }
}
