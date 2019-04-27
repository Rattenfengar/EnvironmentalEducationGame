using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public RawImage bgSky;
    public GameObject idleText;
    public GameObject headerUI;
    public float speedParallax=0.02f;
    private float finalSpeed = 0;
    //Game States
    public enum GameState { Idle, Playing, Pause}
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
        }
        else if (gameState == GameState.Playing && (Input.GetKeyDown(KeyCode.P)))
        {
            gameState = GameState.Pause;
        }
        else if (gameState == GameState.Pause)
        {

        }
        else if (gameState == GameState.Playing)
        {
            Parallax();
        }
        
    }
    void Parallax()
    {
        finalSpeed = speedParallax * Time.deltaTime;
        bgSky.uvRect = new Rect(0f, bgSky.uvRect.y + finalSpeed, 1f, 1f);
    }
}
