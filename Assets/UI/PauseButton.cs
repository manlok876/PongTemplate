using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private IngameMenu ingameMenu = null;
    
    public void OnClick()
    {
        if (PongGame.instance.isPaused)
        {
            ingameMenu.ResumeGame();
        }
        else
        {
            ingameMenu.PauseGame();
        }
    }
}
