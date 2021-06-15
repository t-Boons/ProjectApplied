using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour
{
    private Animator anim;
    private bool isFading;
    private float volume;
    private float volumeAfterFade;

    private AudioSource[] aud;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        aud = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        if (isFading)
        {
            volume = Mathf.Lerp(volume, volumeAfterFade, 6 * Time.deltaTime);

            foreach(var a in aud)
                a.volume = volume;
        }
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
        isFading = true;
        volume = 0;
        volumeAfterFade = 1;

        StartCoroutine(StopFading());
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
        isFading = true;
        volume = 1;
        volumeAfterFade = 0;

        StartCoroutine(StopFading());
    }

    private IEnumerator StopFading()
    {
        yield return new WaitForSeconds(0.99f);
        isFading = false;
    }
}
