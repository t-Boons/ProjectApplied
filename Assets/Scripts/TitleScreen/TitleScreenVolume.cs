using UnityEngine;

public class TitleScreenVolume : MonoBehaviour
{
    public AudioSource titleMusic;

    private void Start()
    {
        FindObjectOfType<UiVolume>().OnChangedSoundValues += ChangeVolume;
    }

    private void ChangeVolume()
    {
        titleMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        titleMusic.mute = PlayerPrefs.GetInt("Muted") >= 1;
    }
}
