using UnityEngine;

public class DialogueIndex : MonoBehaviour
{
    public int currentIndex = -1;

    public uint GetCurrentIndex()
    {
        currentIndex++;
        return (uint)currentIndex;
    }

}
