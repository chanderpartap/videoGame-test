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
    private static InGameView sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }
    public static InGameView GetInstance()
    {
        return sharedInstance;
    }
    // Update is called once per frame
    public void ShowHighestScore()
    {
        highestScoreText.text = PlayerController.GetInstance().GetMaxScore().ToString();
    }
    void Update()
    {
        if(GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            scoreLabel.text = PlayerController.GetInstance().GetDistance().ToString();
        }
    }
    public void UpdateCoins()
    {
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
    }
}
