using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private GameLogic gameLogic;

    public int gameTimeInitalMinutes = 10;
    [SerializeField] private int gameTimeWhiteMinutes;
    [SerializeField] private float gameTimeWhiteSeconds;
    [SerializeField] private int gameTimeBlackMinutes;
    [SerializeField] private float gameTimeBlackSeconds;
    private TMP_Text whiteText;
    private TMP_Text blackText;
    private float deltaTimer;
    void Start()
    {
        gameLogic = GameObject.Find("GameHandler").GetComponent<GameLogic>();
        whiteText = GameObject.Find("WhiteTimerText").GetComponent<TMP_Text>();
        blackText = GameObject.Find("BlackTimerText").GetComponent<TMP_Text>();
        gameTimeWhiteMinutes = gameTimeInitalMinutes;
        gameTimeBlackMinutes = gameTimeInitalMinutes;
    }
    void FixedUpdate()
    {
        switch (gameLogic.currentPlayerColor)   //Switch between players timers
        {
            case (GameLogic.PiecesColor.white):
                {
                    gameTimeWhiteSeconds -= Time.deltaTime;
                    if (gameTimeWhiteSeconds < 0)   //If minute passes
                    {
                        gameTimeWhiteSeconds = 60;
                        gameTimeWhiteMinutes--;
                    }
                    whiteText.text = gameTimeWhiteMinutes.ToString() + ":" + ((int)gameTimeWhiteSeconds).ToString();    //Change display text
                    break;
                }
            case (GameLogic.PiecesColor.black):
                {
                    gameTimeBlackSeconds -= Time.deltaTime;
                    if (gameTimeBlackSeconds < 0)   //If minute passes
                    {
                        gameTimeBlackSeconds = 60;
                        gameTimeBlackMinutes--;
                    }
                    blackText.text = gameTimeBlackMinutes.ToString() + ":" + ((int)gameTimeBlackSeconds).ToString();    //Change display text
                    break;
                }
        }
    }
}
