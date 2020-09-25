using System;
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

    private void AttachToArbiter()
    {
        ScoringRules arbiter = FindObjectOfType<ScoringRules>();
        if (arbiter != null)
        {
            arbiter.OnPlayerScored += OnPlayerScored;
        }
    }
    private void DetachFromArbiter()
    {
        ScoringRules arbiter = FindObjectOfType<ScoringRules>();
        if (arbiter != null)
        {
            arbiter.OnPlayerScored -= OnPlayerScored;
        }
    }
    void OnPlayerScored(int playerIndex)
    {
        // Check player index 

        gameState.playerScores[playerIndex]++;
        gameUI.UpdateScore(playerIndex, gameState.playerScores[playerIndex]);

        GameObject ball = GameObject.FindWithTag("Ball");
        if (ball != null)
        {
            Destroy(ball, 0.5f);
        }
    }
    #endregion

    #region UI
    [SerializeField]
    private PongGameUI gameUI = null;
    #endregion

    void Awake()
    {
        EnsureInstanceExists();
        if (instance != this)
        {
            return;
        }

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    #region GameFlow
    public bool isPaused { get; private set; } = false;

    public void Pause()
    {
        if (isPaused)
        {
            return;
        }

        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        if (!isPaused)
        {
            return;
        }

        Time.timeScale = 1;
        isPaused = false;
    }

    public void ChangeLevel(string levelName)
    {
        Unpause();
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.name == "MainMenu")
        {
            return;
        }

        ResetGameState();
        AttachToArbiter();
    }
    #endregion

    #region MainMenu
    public void StartGame()
    {
        ChangeLevel("BasicPong");
    }

    public void ReturnToMainMenu()
    {
        ChangeLevel("MainMenu");
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
