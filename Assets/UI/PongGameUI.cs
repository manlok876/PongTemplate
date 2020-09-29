using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// In-game UI, with scores, time, etc.
public class PongGameUI : MonoBehaviour
{
    #region Score
    [SerializeField]
    private TextMeshProUGUI[] scoreTexts = null;

    public void UpdateScore(int playerNum, float score)
    {
        // Check player index

        string scoreText = ((int)score).ToString();

        scoreTexts[playerNum].SetText(scoreText);
    }
    #endregion

    void Awake()
    {
        PongGame game = FindObjectOfType<PongGame>();

        if (game != null)
        {
            game.SubscribeUI(this);
        }
    }
}
