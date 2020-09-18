using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject ingameMenu = null;
    
    public void OnClick()
    {
        PongGame game = PongGame.instance;

        if (game.isPaused)
        {
            game.Unpause();
            ingameMenu.SetActive(false);
        }
        else
        {
            game.Pause();
            ingameMenu.SetActive(true);
        }
    }
}
