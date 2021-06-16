using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class DialogueSound : MonoBehaviour
{
    [Header("Button sounds")]
    public AudioClip buttonHover;
    public AudioClip buttonClick;

    [Header("Skip Interval")]
    public uint characterSkipInterval;

    private uint currentIndex;
    private uint charSkipIndex;
    private AudioSource[] audioSource;
    private AudioClip currentSound;

    private void Awake()
    {
        // Creates audiosource objects
        audioSource = new AudioSource[2];
        audioSource[0] = gameObject.AddComponent<AudioSource>();
        audioSource[1] = gameObject.AddComponent<AudioSource>();

        audioSource[1].loop = true;

        GetComponent<DialogueController>().OnUpdateCharacter += PlayVoice;
        GetComponent<DialogueController>().OnUpdateTextIndex += UpdateIndex;


        if(FindObjectOfType<DialogueHolder>())
            PlayMusic(FindObjectOfType<DialogueHolder>().beginMusic);
    
        if(FindObjectOfType<DialogueHolder>().GetDialogueComponent(0).soundType != null)
            currentSound = FindObjectOfType<DialogueHolder>().GetDialogueComponent(0).soundType;

        UpdateVolumeSettings();
    }

    private void UpdateVolumeSettings()
    {
        // Adds event for volume || mute value updates
        FindObjectOfType<UiVolume>().OnChangedSoundValues += ChangeSoundValues;

        // PlayerPref Setters Found in UiVolume class
        SetVoiceVolume(PlayerPrefs.GetFloat("VoiceVolume"));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        IsMuted(PlayerPrefs.GetInt("Muted") >= 1);
    }

    private void ChangeSoundValues()
    {
        SetVoiceVolume(PlayerPrefs.GetFloat("VoiceVolume"));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        IsMuted(PlayerPrefs.GetInt("Muted") >= 1);
    }

    private void UpdateIndex(uint index)
    {
        currentIndex = index;

        if(FindObjectOfType<DialogueHolder>().GetDialogueComponent(currentIndex).soundType != null)
            currentSound = FindObjectOfType<DialogueHolder>().GetDialogueComponent(currentIndex).soundType;
    }

    private void PlayVoice(bool isReadChararcter)
    {
        if (isReadChararcter)
            return;

        charSkipIndex++;
        if (charSkipIndex < characterSkipInterval)
            return;
        charSkipIndex = 0;

        if(currentSound != null)
            audioSource[0].PlayOneShot(currentSound);
    }

    public void PlayButtonHover()
    {
        audioSource[1].PlayOneShot(buttonHover);
    }

    public void PlayButtonClick()
    {
        audioSource[1].PlayOneShot(buttonClick);
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null)
            return;

        audioSource[1].Stop();
        audioSource[1].clip = clip;
        audioSource[1].Play();
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource[1].PlayOneShot(sound);
    }

    private void SetVoiceVolume(float volume)
    {
        audioSource[0].volume = volume;
    }

    private void SetMusicVolume(float volume)
    {
        audioSource[1].volume = volume;
    }

    private void IsMuted(bool muted)
    {
        audioSource[0].mute = muted;
        audioSource[1].mute = muted;
    }
}
