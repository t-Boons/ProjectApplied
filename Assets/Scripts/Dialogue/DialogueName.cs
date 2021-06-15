using UnityEngine;

public class DialogueName : MonoBehaviour
{
    public static string playerName = "Player";

    [Header("To be inserted to print name in text")]
    [SerializeField] private string insertName = "#n";

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

        foreach (string word in text.Split(' '))
        {
            if (word == insertName)
                s += playerName;
            else
                s += word;

            s += " ";
        }

        return s;
    }
}
