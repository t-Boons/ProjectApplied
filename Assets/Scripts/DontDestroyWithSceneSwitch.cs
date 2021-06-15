using UnityEngine;

public class DontDestroyWithSceneSwitch : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
