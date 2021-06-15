using UnityEngine;

public class DialogueName : MonoBehaviour
{
    public static string playerName = "Player";

    [Header("To be inserted to print name in text")]
    [SerializeField] private char insertChar = '#';

    public string GetName()
    {
        return playerName;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public string FormatWithName(string text)
    {
        if (text == "" || text == null)
            return "";

        string s = "";

        foreach (char character in text)
        {
            if (character == insertChar)
                s += playerName;
            else
                s += character;
        }

        return s;
    }
}
