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
        if (index >= dialogue.Length)
            return new UnityEvent();
            
        return dialogue[index].action;
    }

    public uint GetLength()
    {
        return (uint)dialogue.Length;
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

        [TextArea(6, 6)]
        public string text;

        public Sprite background;

        [Header("Portaits")]
        public Sprite leftPortrait;
        public Sprite rightPortrait;

}

[System.Serializable]
    public struct Question
    {
        public string answer1;
        public UnityEvent action1;

        public string answer2;
        public UnityEvent action2;

        public string answer3;
        public UnityEvent action3;

}