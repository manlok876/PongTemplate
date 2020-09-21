using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private PongGame game => PongGame.instance;

    public void StartGame()
    {
        game.StartGame();
    }

    public void ExitGame()
    {
        game.ExitGame();
    }
}
