using UnityEngine;

public class TitleScreenVolume : MonoBehaviour
{
    public AudioSource titleMusic;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
            PlayerPrefs.SetFloat("MusicVolume", 1);

        ChangeVolume();
        FindObjectOfType<UiVolume>().OnChangedSoundValues += ChangeVolume;
    }

    private void ChangeVolume()
    {
        titleMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        titleMusic.mute = PlayerPrefs.GetInt("Muted") >= 1;
    }
}
