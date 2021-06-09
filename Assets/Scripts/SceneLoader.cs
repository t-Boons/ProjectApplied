using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(uint index)
    {
        SceneManager.LoadScene((int)index);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
