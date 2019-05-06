using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject Generator;
    public RawImage bgSky;
    public GameObject idleText;
    public GameObject headerUI;
    public GameObject GameOverUI;
    public Text TimeLeftLable;
    public float speedParallax=0.02f;
    private float finalSpeed = 0;
    private float direction = 1;
    public float TimeLeft = 100;
    private AudioSource backgroundSound;
    //Game States
    public enum GameState { Idle, Playing, Pause, GameOver}
    public GameState gameState = GameState.Idle; 
    // Start is called before the first frame update
    void Start()
    {
        backgroundSound = GetComponent<AudioSource>();
        backgroundSound.Play();
        headerUI.SetActive(false);
        GameOverUI.SetActive(false);
        TimeLeftLable.text = TimeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (((gameState == GameState.Idle||gameState==GameState.GameOver) && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0)))|| gameState == GameState.Pause && (Input.GetKeyDown(KeyCode.P)))
        {
            TimeLeft = 100;
            gameState = GameState.Playing;
            headerUI.SetActive(true);
            idleText.SetActive(false);
            Generator.SendMessage("StartGenerator");
            InvokeRepeating("IncreaseSpeed", 10, 10);
            InvokeRepeating("TimeUpdate", 0, 1);
        }
        else if (gameState == GameState.Playing && (Input.GetKeyDown(KeyCode.P)))
        {
            gameState = GameState.Pause;
            Generator.SendMessage("StopGenerator");
        }
        else if (gameState == GameState.Pause)
        {
            Generator.SendMessage("StopGenerator");
        }
        else if (gameState == GameState.Playing)
        {
            Parallax();
        }
        else if(gameState == GameState.GameOver)
        {
            Generator.SendMessage("StopGenerator");
            headerUI.SetActive(false);
            GameOverUI.SetActive(true);

        }
        
    }
    void Parallax()
    {
        finalSpeed = speedParallax * Time.deltaTime*direction;
        bgSky.uvRect = new Rect(bgSky.uvRect.x+finalSpeed, 0f, 1f, 1f);
        if (bgSky.uvRect.x > 0.4)
        {
            direction *= -1;
        }
        if (bgSky.uvRect.x < 0)
        {
            direction *= -1;
        }
    }
    public void GameOver()
    {
        gameState = GameState.GameOver;
    }
    void IncreaseSpeed()
    {
        Generator.SendMessage("StopGenerator");
        Generator.SendMessage("IncreaseSpeed");
        Generator.SendMessage("StartGenerator");
    }
    void TimeUpdate()
    {
        TimeLeft -= 1;
        TimeLeftLable.text = TimeLeft.ToString();
        if (TimeLeft == 0)
        {
            gameState = GameState.GameOver;
        }
    }
}
