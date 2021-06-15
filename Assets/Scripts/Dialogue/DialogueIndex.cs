using UnityEngine;

public class DialogueIndex : MonoBehaviour
{
    public int currentIndex = -1;

    public uint GetCurrentIndex()
    {
        return (uint)currentIndex;
    }

    public void IncrementIndex()
    {
        currentIndex++;
    }

    public void SetIndex(uint index)
    {
        currentIndex = (int)index;
    }
}
