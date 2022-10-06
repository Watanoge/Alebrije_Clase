using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongUI : MonoBehaviour
{
    public int pointsLeftAmount, pointsRightAmount, pointsToWin;
    public TextMeshProUGUI pointsLeft, pointsRight, counterText, winnerText;
    public CanvasGroup counterObject, startGameObject, endGameObject;

    public PongBall ball;
    
    void Start()
    {
        RestartGame();
    }

    public void RestartGame(){
        pointsLeftAmount = pointsRightAmount = 0;
        UpdatePoints(false);
    }

    public void UpdatePoints(bool canStart = true){
        pointsLeft.text = $"{pointsLeftAmount}";
        pointsRight.text = $"{pointsRightAmount}";

        if(pointsLeftAmount >= pointsToWin){
            endGameObject.gameObject.SetActive(true);
            winnerText.text = "JUGADOR IZQUIERDA GANÓ";
            GameManager.instance.CanvasGroupFade(0, 1, 0.5f, endGameObject);
        }else if(pointsRightAmount >= pointsToWin){
            endGameObject.gameObject.SetActive(true);
            winnerText.text = "JUGADOR DERECHA GANÓ";
            GameManager.instance.CanvasGroupFade(0, 1, 0.5f, endGameObject);
        }else if(canStart){
            GameStart();
        }
    }

    public void FadeStartObject(bool fadeIn){
        if(fadeIn){
            GameManager.instance.CanvasGroupFade(0, 1, 0.5f, startGameObject);
        }else{
            GameManager.instance.CanvasGroupFade(1, 0, 0.5f, startGameObject);
        }
    }

    public void FadeEndGameObject(bool fadeIn){
        if(fadeIn){
            GameManager.instance.CanvasGroupFade(0, 1, 0.5f, endGameObject);
        }else{
            GameManager.instance.CanvasGroupFade(1, 0, 0.5f, endGameObject);
        }
    }

    public void AddPointsToLeft(){
        pointsLeftAmount++;
        UpdatePoints();
    }

    public void AddPointsToRight(){
        pointsRightAmount++;
        UpdatePoints();
    }

    public void GameStart(){
        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine(){
        counterText.text = "3";   
        GameManager.instance.CanvasGroupFade(0, 1, 0.5f, counterObject);

        yield return new WaitForSeconds(1);
        counterText.text = "2";
        yield return new WaitForSeconds(1);
        counterText.text = "1";
        yield return new WaitForSeconds(1);
        counterText.text = "0";
        GameManager.instance.CanvasGroupFade(1, 0, 0.5f, counterObject);
        yield return new WaitForSeconds(1);
        ball.Launch();
    }
}
