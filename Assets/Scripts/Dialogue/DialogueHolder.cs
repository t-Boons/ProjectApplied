using UnityEngine;
using UnityEngine.Events;

public class DialogueHolder : MonoBehaviour
{
    [Header("Main component array")]
    public DialogueObject[] dialogue; 

    public DialogueComponent GetDialogueComponent(uint index)
    {
        if (index >= dialogue.Length)
            return new DialogueComponent();

        return dialogue[index].component;
    }

    public Question GetQuestion(uint index)
    {
        if (index >= dialogue.Length)
            return new Question();

        return dialogue[index].question;
    }

    public UnityEvent GetEvent(uint index)
    {
        return dialogue[index].action;
    }
}

[System.Serializable]
public class DialogueObject
{
    public DialogueComponent component;
    public Question question;

    [Header("Event")]
    public UnityEvent action;
}

    [System.Serializable]
    public struct DialogueComponent
    {
        public string talker;
        public string text;
        public Sprite background;
    }

    [System.Serializable]
    public struct Question
    {
        public bool isEnabled;
        public string answer1;
        public string answer2;
        public string answer3;
    }