using UnityEngine;
using UnityEngine.UI;

public class UiVolume : MonoBehaviour
{
    public event System.Action OnChangedSoundValues = delegate { };

    public Slider musicSlider;
    public Slider voiceSlider;
    public Toggle muteButton;

    private void Awake()
    {
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        muteButton.isOn = PlayerPrefs.GetInt("Muted") >= 1;
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        OnChangedSoundValues();
    }

    public void SetVoiceVolume(float volume)
    {
        PlayerPrefs.SetFloat("VoiceVolume", volume);
        OnChangedSoundValues();
    }

    public void SetMuted(bool muted)
    {
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
        OnChangedSoundValues();
    }
}
