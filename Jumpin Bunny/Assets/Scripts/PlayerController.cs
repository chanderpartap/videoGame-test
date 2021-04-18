using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 10.0f;
    private Vector3 initialPosition;
    private Vector2 initialVelocity;
    private const string HIGH_SCORE_KEY = "highestScore";
    
    //public Vector2 speed = new Vector2(1, 1);

    private static PlayerController sharedInstance;
    //Implementing Singleton
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sharedInstance = this;
        initialPosition = transform.position;
        initialVelocity = rigidBody.velocity;
        animator.SetBool("isAlive", true);
    }
    //Getter Method for sharedInstance
    public static PlayerController GetInstance()
    {
        return sharedInstance;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        transform.position = initialPosition;
        rigidBody.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        bool isOnGround = IsOnGround();
        //print("is Ground = " + isOnGround);
        animator.SetBool("isGrounded", isOnGround);
        if (GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            if ((Input.GetMouseButtonDown(0)
                || Input.GetKeyDown(KeyCode.Space)
                || Input.GetKeyDown(KeyCode.W)) && isOnGround)
            {
                //print("Left button or space or w pressed!");
                jump();
            }
        }
    }
    private void FixedUpdate() { 
        if (GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            if (rigidBody.velocity.x < runSpeed)
            {
                rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            }
        }
        /* To move front and back
        float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(speed.x * inputX, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);*/
    }

    void jump()
    {
        rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }
    bool IsOnGround()
    {
        //print("Mask = " + groundLayerMask);
        return Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value);
    }

    public void KillPlayer()
    {
        animator.SetBool("isAlive", false);
        GameManager.GetInstance().GameOver();
        int highestScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY); // playerprefab to store preferences 
        int currentScore = GetDistance();
        if(currentScore > highestScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentScore); //setting high score
        }
    }

    public int GetDistance()
    {
        var distance = (int) Vector2.Distance(initialPosition, transform.position);

        return distance;
    }
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
    }
}
