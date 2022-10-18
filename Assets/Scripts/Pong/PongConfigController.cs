using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PongConfigController : MonoBehaviour
{
    /*
    public float ballSpeed = 7.5;
    public float playerSpeed = 20;
    public int pointsToWin = 3;*/

    public Slider ballSpeedField, playerSpeedField, pointsToWinField;
    public TextMeshProUGUI ballSpeedText, playerSpeedText, pointsToWinText; 

    void Awake(){
        StartValues();
    }

    public void StartValues(){
        ballSpeedField.value = GameManager.instance.currentConfig.pong.ballSpeed;
        ballSpeedText.text = $"Velocidad Pelota ({ballSpeedField.value})";

        playerSpeedField.value = GameManager.instance.currentConfig.pong.playerSpeed;
        playerSpeedText.text = $"Velocidad Paleta ({playerSpeedField.value})";

        pointsToWinField.value = GameManager.instance.currentConfig.pong.pointsToWin;
        pointsToWinText.text = $"Puntos para ganar ({pointsToWinField.value})";
    }

    public void SetBallSpeed(float ballSpeed){
        GameManager.instance.currentConfig.pong.ballSpeed = ballSpeed;
        StartValues();
    }

    public void SetPlayerSpeed(float playerSpeed){
        GameManager.instance.currentConfig.pong.playerSpeed = playerSpeed;
        StartValues();
    }

    public void SetPointsToWin(float pointsToWin){
        GameManager.instance.currentConfig.pong.pointsToWin = (int)pointsToWin;
        StartValues();
    }

    // public float ValidateValues(string _val, float min, float max){
    //     if(_val.Length == 0 || _val == null)
    //         return min;

    //     float val = float.Parse(_val);
    //     if(val <= min) val = min;
    //     if(val >= max) val = max;

    //     return val;
    // }

    // public void SetBallSpeed(string ballSpeed){
    //     GameManager.instance.currentConfig.pong.ballSpeed = ValidateValues(ballSpeed, 1, 10);
    //     StartValues();
    // }

    // public void SetPlayerSpeed(string playerSpeed){
    //     GameManager.instance.currentConfig.pong.playerSpeed = ValidateValues(playerSpeed, 1, 30);
    //     StartValues();
    // }

    // public void SetPointsToWin(string pointsToWin){
    //     GameManager.instance.currentConfig.pong.pointsToWin = (int) ValidateValues(pointsToWin, 1, 100);
    //     StartValues();

    //     // int val; //Declaramos una variable
    //     // bool couldParse = int.TryParse(pointsToWin, out val);
    //     //Intentamos parsear "pointsToWin" - si se logra, asignará el valor a "val" y regresará "true". De lo contrario, regresará "false" y "val" no tendrá cambios

    //     // if(couldParse){ //Esto es verdad si y solo si el TryParse se logró hacer

    //     // }
    // }
}
