using UnityEngine;
using UnityEngine.Events;

[ExecuteAlways]
public class DialogueHolder : MonoBehaviour
{
    [Header("Begin music (leave empty for no music)")]
    public AudioClip beginMusic;

    [Header("Main component array")]
    public DialogueObject[] dialogue;

    private void Update()
    {
        FixQuestions();
    }

    private void FixQuestions()
    {
        if (dialogue == null)
            return;

        foreach(var d in dialogue)
        {
            // Fine
            if (d.question.answer1 != "" &&
                d.question.answer2 != "" &&
                d.question.answer3 != "")
                continue;

            if (d.question.answer1 == "" &&
                d.question.answer2 == "" &&
                d.question.answer3 == "")
                continue;

            // Only 2 and 3
            if (d.question.answer1 == "" &&
                d.question.answer2 != "" &&
                d.question.answer3 != "")
            {
                d.question.answer1 = d.question.answer2;
                d.question.action1 = d.question.action2;

                d.question.answer2 = d.question.answer3;
                d.question.action2 = d.question.action3;

                d.question.answer3 = "";
                d.question.action3 = null;
            }

            // Only 1 and 3
            if (d.question.answer1 != "" &&
                d.question.answer2 == "" &&
                d.question.answer3 != "")
            {
                d.question.answer2 = d.question.answer3;
                d.question.action2 = d.question.action3;

                d.question.answer3 = "";
                d.question.action3 = null;
            }
        }
    }

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
            
        return dialogue[index].component.action;
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
}

    [System.Serializable]
    public struct DialogueComponent
    {
        public string talker;

        [Header("Talking Sound")]
        public AudioClip soundType;

        [TextArea(6, 6)]
        public string text;

        public Sprite background;

        [Header("Portaits")]
        public Sprite leftPortrait;
        public Sprite rightPortrait;

        [Header("Event")]
        public UnityEvent action;
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