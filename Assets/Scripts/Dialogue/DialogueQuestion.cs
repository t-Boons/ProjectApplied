using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DialogueController))]
public class DialogueQuestion : MonoBehaviour
{
    [Header("Button references")]
    public Button button1;
    public Button button2;
    public Button button3;

    private uint currentIndex;
    private bool hasOverlayOpen;

    void Start()
    {
        GetComponent<DialogueController>().OnUpdateTextIndex += SetActiveButtons;

        button1.onClick.AddListener(delegate { PickedAnswer(1); });
        button2.onClick.AddListener(delegate { PickedAnswer(2); });
        button3.onClick.AddListener(delegate { PickedAnswer(3); });

        DisableButtons();
    }

    public void SetActiveButtons(uint index)
    {
        currentIndex = index;

        if (currentIndex >= FindObjectOfType<DialogueHolder>().GetLength())
            return;

        Question q = FindObjectOfType<DialogueHolder>().GetQuestion(currentIndex);


        int activeButtonCount = GetActiveButtonCount(q);
        if (activeButtonCount == -1)
                return;

        EnableButtons((uint)activeButtonCount, q);
        SetValidPosition((uint)activeButtonCount);

        hasOverlayOpen = true;
    }

    private void SetValidPosition(uint buttonCount)
    {
        RectTransform b1rect = button1.GetComponent<RectTransform>();
        RectTransform b2rect = button2.GetComponent<RectTransform>();
        RectTransform b3rect = button3.GetComponent<RectTransform>();

        switch (buttonCount)
        {
            case 1: 
                b1rect.anchoredPosition = new Vector2(0, b1rect.rect.y);
                break;

            case 2:
                b1rect.anchoredPosition = new Vector2(-170, b1rect.rect.y);
                b2rect.anchoredPosition = new Vector2(170, b1rect.rect.y);
                break;

            case 3:
                b1rect.anchoredPosition = new Vector2(-300, b1rect.rect.y);
                b2rect.anchoredPosition = new Vector2(0, b1rect.rect.y);
                b3rect.anchoredPosition = new Vector2(300, b1rect.rect.y);
                break;
            default: Debug.LogError("Butten out of range"); break;
        }
    }

    private int GetActiveButtonCount(Question q)
    {
        int activeButtonCount = 0;

        if (q.answer1 != "") activeButtonCount++;
        if (q.answer2 != "") activeButtonCount++;
        if (q.answer3 != "") activeButtonCount++;

        if (activeButtonCount == 0)
            return -1;

        return activeButtonCount;
    }

    private void EnableButtons(uint count, Question question)
    {
        GetComponent<DialogueController>().PauseDialogue(true);

        if (count >= 1)
        {
            button1.gameObject.SetActive(true);
            button1.GetComponentInChildren<Text>().text = question.answer1;
        }

        if (count >= 2)
        {
            button2.gameObject.SetActive(true);
            button2.GetComponentInChildren<Text>().text = question.answer2;
        }

        if (count >= 3)
        {
            button3.gameObject.SetActive(true);
            button3.GetComponentInChildren<Text>().text = question.answer3;
        }
    }

    private void PickedAnswer(uint answer)
    {
        Question q = FindObjectOfType<DialogueHolder>().GetQuestion(currentIndex);
        
        switch(answer)
        {
            case 1: if(q.action1 != null) q.action1.Invoke(); break;
            case 2: if(q.action2 != null) q.action2.Invoke(); break;
            case 3: if(q.action3 != null) q.action3.Invoke(); break;
            default: Debug.LogError("Question out of range"); break;
        }

        GetComponent<DialogueController>().PauseDialogue(false);

        DisableButtons();

        hasOverlayOpen = false;
    }

    private void DisableButtons()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
    }

    public bool IsPausedByQuestion()
    {
        return hasOverlayOpen;
    }
}
