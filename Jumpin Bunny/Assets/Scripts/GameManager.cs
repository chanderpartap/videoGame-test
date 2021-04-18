using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* <summary>
/// 1> Main Menu
/// 2> In Game
/// 3> Game Over
/// 4> Pause
/ </summary>*/

public enum GameState
{
    Menu,
    InGame,
    GameOver,
    Resume
}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.Menu; //Default value
    private static GameManager sharedInstance;
    public Canvas menuCanvas;
    public Canvas gameMenu;
    public Canvas gameOver;
    public Canvas creditsCanvas;
    public int collectedCoins = 0;
    //Implementing Singleton
    private void Awake()
    {
        sharedInstance = this;
    }
    //Getter Method for sharedInstance
    public static GameManager GetInstance()
    {
        return sharedInstance;
    }
    // Start and Update not required
    //To Start Game
    public void Start()
    {
        currentGameState = GameState.Menu;
        menuCanvas.enabled = true;
        gameMenu.enabled = false;
        gameOver.enabled = false;
        creditsCanvas.enabled = false;
    }
    public void StartGame()
    {
        PlayerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
        LevelGenerator.sharedInstance.CreateInitialBlocks();
        InGameView.GetInstance().ShowHighestScore();
    }
    //To End Game
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        GameOverView.GetInstance().UpdateGUI();
    }
    //When player wants to Quit the game and go back to main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }

    public void Resume()
    {
        ChangeGameState(GameState.Resume);
    }
    //Method to help change states
    //All logic goes here (mostly)
    void ChangeGameState(GameState newGameState)
    {
        if(newGameState == GameState.Menu)
        {
            //Load Main Menu
            menuCanvas.enabled = true;
            gameMenu.enabled = false;
            gameOver.enabled = false;
            creditsCanvas.enabled = false;

        } else if(newGameState == GameState.InGame)
        {
            //Load the Game
            menuCanvas.enabled = false;
            gameMenu.enabled = true;
            gameOver.enabled = false;
            creditsCanvas.enabled = false;

        } else if(newGameState == GameState.GameOver)
        {
            //Load Scores or End game
            menuCanvas.enabled = false;
            gameMenu.enabled = false;
            gameOver.enabled = true;
            creditsCanvas.enabled = false;

        } else if(newGameState == GameState.Resume)
        {
            menuCanvas.enabled = false;
            gameMenu.enabled = false;
            gameOver.enabled = false;
            creditsCanvas.enabled = true;
        }
        else
        {
            newGameState = GameState.Menu;
        }
        currentGameState = newGameState;

    }
    private void Update()
    {
        if (currentGameState != GameState.InGame && Input.GetKey("s"))
        {
            ChangeGameState(GameState.InGame);
            StartGame();
        }
    }

    public void CollectCoins()
    {
        collectedCoins++;
        InGameView.GetInstance().UpdateCoins();
    }
    public int GetCollectedCoins()
    {
        return collectedCoins;
    }
}
