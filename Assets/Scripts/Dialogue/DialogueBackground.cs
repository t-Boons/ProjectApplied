using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DialogueController))]
public class DialogueBackground : MonoBehaviour
{
    public Image backgroundReference;

    [Header("Portrait references")]
    public Image portraitLeftReference;
    public Image portraitRightReference;

    void Start()
    {
        GetComponent<DialogueController>().OnUpdateTextIndex += ChangeBackground;
        ChangeBackground(0);
    }

    public void ChangeBackground(uint index)
    {
        DialogueComponent currentDialogue = FindObjectOfType<DialogueHolder>().GetDialogueComponent(index);

        if (currentDialogue.background != null)
            backgroundReference.sprite = currentDialogue.background;


        if (currentDialogue.leftPortrait != null)
        {
            portraitLeftReference.color = new Color(1, 1, 1, 1);
            portraitLeftReference.sprite = currentDialogue.leftPortrait;
        }
        else
            portraitLeftReference.color = new Color(0, 0, 0, 0);


        if (currentDialogue.rightPortrait != null)
        {
            portraitRightReference.color = new Color(1, 1, 1, 1);
            portraitRightReference.sprite = currentDialogue.rightPortrait;
        }
        else
            portraitRightReference.color = new Color(0, 0, 0, 0);
    }
}
