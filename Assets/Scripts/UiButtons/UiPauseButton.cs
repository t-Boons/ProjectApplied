using UnityEngine;

public class UiPauseButton : MonoBehaviour
{
    public Canvas pauseUi;

    public void Start()
    {
        DialogueController controller = FindObjectOfType<DialogueController>();

        pauseUi.enabled = false;
    }

    public void Pause(bool pause)
    {
        DialogueController controller = FindObjectOfType<DialogueController>();

        if (FindObjectOfType<DialogueQuestion>())
        {
            if (FindObjectOfType<DialogueQuestion>().IsPausedByQuestion())
                return;
        }

        pauseUi.enabled = !controller.GetPaused();
        controller.PauseDialogue(!controller.GetPaused());
    }
}
