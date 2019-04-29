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
    public float speedParallax=0.02f;
    private float finalSpeed = 0;
    private float direction = 1;
    //Game States
    public enum GameState { Idle, Playing, Pause, GameOver}
    public GameState gameState = GameState.Idle; 
    // Start is called before the first frame update
    void Start()
    {
        headerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameState == GameState.Idle && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0)))|| gameState == GameState.Pause && (Input.GetKeyDown(KeyCode.P)))
        {
            gameState = GameState.Playing;
            headerUI.SetActive(true);
            idleText.SetActive(false);
            Generator.SendMessage("StartGenerator");
        }
        else if (gameState == GameState.Playing && (Input.GetKeyDown(KeyCode.P)))
        {
            gameState = GameState.Pause;
            Generator.SendMessage("CancelGenerator");
        }
        else if (gameState == GameState.Pause)
        {
            Generator.SendMessage("CancelGenerator");
        }
        else if (gameState == GameState.Playing)
        {
            Parallax();
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
}
