using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void StartGame()
    {
        PlayerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
    }
    //To End Game
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
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

        } else if(newGameState == GameState.InGame)
        {
            //Load the Game

        } else if(newGameState == GameState.GameOver)
        {
            //Load Scores or End game

        } else if(newGameState == GameState.Resume)
        {
            //Load Pause Menu
        }
        else
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
