using UnityEngine;

public class PongGame : MonoBehaviour
{
    public static PongGame instance { get; private set; } = null;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
