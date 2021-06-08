using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public enum DialogueMode { Click, Auto, Script }

public class DialogueController : MonoBehaviour
{
    [Header("Speed at which the dialogue is played at.")]
    public float dialogueInterval;
    public float dialoguePauseDuration;

    [Header("Text to display dialogue on.")]
    public Text dialogueText;
    public Text talkerText;

    [Header("Set dialogue mode.")]
    public DialogueMode dialogueMode;

    [Header("Dialogue objects")]
    public DialogueHolder dialogueTextHolder;
    public DialogueIndex dialogueIndex;


    private uint currentTextIndex;
    private string finalText, currentText;
    private string talkerName;
    private uint currentCharacterIndex;
    private bool isDoneWriting, isDoneWithCharacter, isDoneWaiting, hasAborted;

    public event Action<uint> OnUpdateTextIndex;

    private void NextDialogue()
    {
        ResetText();
        GetNewTextValues();
        ExecuteEventAction();
        OnUpdateTextIndex(currentTextIndex);
        SetName(talkerName);


        isDoneWriting = false;
    }

    private void ExecuteEventAction()
    {
        dialogueTextHolder.GetEvent(currentTextIndex).Invoke();
    }

    private void GetNewTextValues()
    {
        currentTextIndex = dialogueIndex.GetCurrentIndex();
    
        finalText = dialogueTextHolder.GetDialogueComponent(currentTextIndex).text;
        talkerName = dialogueTextHolder.GetDialogueComponent(currentTextIndex).talker;

        if (finalText == null || talkerName == null)
            Abort();
    }

    private void Abort()
    {
        SetText("");
        SetName("");
        hasAborted = true;
        enabled = false;
    }

    private void ResetText()
    {
        currentText = "";
        currentCharacterIndex = 0;
        isDoneWithCharacter = true;
    }

    private void Start()
    {
        isDoneWriting = true;
        isDoneWaiting = true;
        hasAborted = false;
    }

    private void Update()
    {
        CheckMode();

        if (!isDoneWriting &&
            isDoneWaiting &&
            !hasAborted)
            NextCharacter();
    }

    private void NextCharacter()
    {
        if ((uint)finalText.Length == currentCharacterIndex)
        {
            FinishSentence();
            return;
        }

        if (isDoneWithCharacter)
        {
            isDoneWithCharacter = false;
            StartCoroutine(LoadNextCharacter());
        }
    }

    private IEnumerator LoadNextCharacter()
    {
        currentText += finalText[(int)currentCharacterIndex];
        SetText(currentText);

        currentCharacterIndex++;

        yield return new WaitForSeconds(dialogueInterval);
        isDoneWithCharacter = true;
    }

    private void SetName(string name)
    {
        talkerText.text = name;
    }

    private void SetText(string text)
    {
        dialogueText.text = text;
    }

    private void CheckMode()
    {
        switch (dialogueMode)
        {
            case DialogueMode.Click:
                CheckForClick();
                break;
            case DialogueMode.Auto:
                AutomaticDialogue();
                break;
        }
    }

    private void FinishSentence()
    {
        SetText(finalText);
        isDoneWriting = true;
    }

    private void CheckForClick()
    {
        if (Input.GetMouseButtonDown(0))
            if (isDoneWriting)
                NextDialogue();
            else
                FinishSentence();
    }

    private void AutomaticDialogue()
    {
        if (isDoneWriting && isDoneWaiting)
        {
            isDoneWaiting = false;
            StartCoroutine(StartNewDialogue());
        }
    }

    private IEnumerator StartNewDialogue()
    {
        yield return new WaitForSeconds(dialoguePauseDuration);
        isDoneWaiting = true;
        NextDialogue();
    }
}
