using UnityEngine;

public class TitleScreenAutoFade : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<FadeController>().FadeIn();
    }
}
