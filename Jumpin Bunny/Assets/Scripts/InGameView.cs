using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameView : MonoBehaviour
{
    public TMP_Text coinsLabel;
    public TMP_Text scoreLabel;
    public TMP_Text highestScoreText;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            highestScoreText.text = PlayerController.GetInstance().GetMaxScore().ToString();
        }
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
        scoreLabel.text = PlayerController.GetInstance().GetDistance().ToString();
    }
}
