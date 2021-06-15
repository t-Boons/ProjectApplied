using UnityEngine;
using UnityEngine.UI;

public class UiModeButton : MonoBehaviour
{
    private static DialogueMode mode = DialogueMode.Click;

    public Button modeButton;
    public Image speedupImage;

    public void Start()
    {
        DialogueController controller = FindObjectOfType<DialogueController>();

        controller.SetDialogueMode(mode);

        if (controller.GetDialogueMode() == DialogueMode.Auto)
            speedupImage.enabled = true;
        else
            speedupImage.enabled = false;
    }

    public void SwitchMode()
    {
        DialogueController controller = FindObjectOfType<DialogueController>();

        if (controller.GetDialogueMode() == DialogueMode.Auto)
        {
            controller.SetDialogueMode(DialogueMode.Click);
            mode = DialogueMode.Click;
            speedupImage.enabled = false;
        }
        else if (controller.GetDialogueMode() == DialogueMode.Click)
        {
            controller.SetDialogueMode(DialogueMode.Auto);
            mode = DialogueMode.Auto;
            speedupImage.enabled = true;
        }
    }
}
