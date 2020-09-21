using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MonoBehaviour
{
    private PongGame game => PongGame.instance;

    public void PauseGame()
    {
        if (game.isPaused)
        {
            return;
        }

        gameObject.SetActive(true);
        game.Pause();
    }

    public void ResumeGame()
    {
        if (!game.isPaused)
        {
            return;
        }

        gameObject.SetActive(false);
        game.Unpause();
    }

    public void ReturnToMenu()
    {
        game.ReturnToMainMenu();
    }
}
