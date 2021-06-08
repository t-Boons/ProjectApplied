using UnityEngine;
using UnityEngine.UI;

public class DialogueBackground : MonoBehaviour
{
    [Header("Background reference")]
    public Image background;

    void Start()
    {
        FindObjectOfType<DialogueController>().OnUpdateTextIndex += ChangeBackground;
    }

    public void ChangeBackground(uint index)
    {
        background.sprite = FindObjectOfType<DialogueHolder>().GetDialogueComponent(index).background;
    }
}
