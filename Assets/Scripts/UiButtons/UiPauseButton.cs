using UnityEngine;

public class UiPauseButton : MonoBehaviour
{
    public void Pause(bool pause)
    {
        DialogueController controller = FindObjectOfType<DialogueController>();

        if (FindObjectOfType<DialogueQuestion>())
        {
            if (FindObjectOfType<DialogueQuestion>().IsPausedByQuestion())
                return;
        }

        controller.PauseDialogue(!controller.GetPaused());
    }
}
