using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DialogueController))]
public class DialogueBackground : MonoBehaviour
{
    public Image backgroundReference;

    void Start()
    {
        GetComponent<DialogueController>().OnUpdateTextIndex += ChangeBackground;
    }

    public void ChangeBackground(uint index)
    {
        backgroundReference.sprite = GetComponent<DialogueHolder>().GetDialogueComponent(index).background;
    }
}
