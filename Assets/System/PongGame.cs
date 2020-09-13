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

    #region GameState
    public class PongGameState
    {
        public int numPlayers = 2;
        public int[] playerScores = new int[2] { 0, 0 };
    }

    public PongGameState gameState { get; private set; } = new PongGameState();
    private void ResetGameState()
    {
        gameState = new PongGameState();
    }
    #endregion

    #region UI
    [SerializeField]
    private PongGameUI gameUI = null;
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
