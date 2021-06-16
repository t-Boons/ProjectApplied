using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour
{
    private Animator anim;
    private bool isFading;

    private AudioSource[] aud;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        aud = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        if (isFading)
        {
            foreach(var a in aud)
                a.volume -= 1 * Time.deltaTime;
        }
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
        StartCoroutine(StopFading());
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
        isFading = true;
        StartCoroutine(StopFading());
    }

    private IEnumerator StopFading()
    {
        yield return new WaitForSeconds(0.99f);
        isFading = false;
    }
}
