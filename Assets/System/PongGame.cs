using UnityEngine;
using UnityEngine.SceneManagement;

public class PongGame : MonoBehaviour
{
    #region Singleton
    public static PongGame instance { get; private set; } = null;
    private void EnsureInstanceExists()
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
    #endregion

    void Awake()
    {
        EnsureInstanceExists();
    }


    #region MainMenu
    public void StartGame()
    {
        ChangeLevel("BasicPong");
    }

    public void ChangeLevel(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    #endregion
}
