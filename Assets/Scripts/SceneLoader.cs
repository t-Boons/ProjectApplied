using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private static bool isFadeEnabled;

    private FadeController controller;

    private void Start()
    {
        if (FindObjectOfType<FadeController>())
            controller = FindObjectOfType<FadeController>();
        else
        {
            Debug.LogWarning("Fade object not found!");
            isFadeEnabled = false;
        }

        if (isFadeEnabled)
            controller.FadeIn();
    }

    public void EnableFade(bool enabled)
    {
        if(controller != null)
            isFadeEnabled = enabled;
    }

    public void LoadScene(int index)
    {
        if (isFadeEnabled)
        {
            isFadeEnabled = true;
            StartCoroutine(FadeToScene(index));
            return;
        }
        isFadeEnabled = false;
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string name)
    {
        if (isFadeEnabled)
        {
            isFadeEnabled = true;
            StartCoroutine(FadeToScene(name));
            return;
        }
        isFadeEnabled = false;
        SceneManager.LoadScene(name);
    }

    private IEnumerator FadeToScene(int index)
    {
        controller.FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);

    }

    private IEnumerator FadeToScene(string name)
    {
        controller.FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);

    }
}
