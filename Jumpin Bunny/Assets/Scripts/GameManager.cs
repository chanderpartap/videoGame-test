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
    }
    public void StartGame()
    {
        PlayerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
        LevelGenerator.sharedInstance.CreateInitialBlocks();
    }
    //To End Game
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
        LevelGenerator.sharedInstance.RemoveAllBlocks();
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

        } else if(newGameState == GameState.InGame)
        {
            //Load the Game
            menuCanvas.enabled = false;
            gameMenu.enabled = true;
            gameOver.enabled = false;

        } else if(newGameState == GameState.GameOver)
        {
            //Load Scores or End game
            menuCanvas.enabled = false;
            gameMenu.enabled = false;
            gameOver.enabled = true;

        } else
        {
            newGameState = GameState.Menu;
        }
        //Construct Swith in Scripting
        /*
         * switch(newGameState)
         * {
         * case GameState.Menu
         *Load menu
         *break;
         * }
         */
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

}
