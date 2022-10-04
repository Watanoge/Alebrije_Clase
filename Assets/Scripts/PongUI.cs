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
            CanvasGroupFade(0, 1, 0.5f, endGameObject);
        }else if(pointsRightAmount >= pointsToWin){
            endGameObject.gameObject.SetActive(true);
            winnerText.text = "JUGADOR DERECHA GANÓ";
            CanvasGroupFade(0, 1, 0.5f, endGameObject);
        }else if(canStart){
            GameStart();
        }
    }

    public void FadeStartObject(bool fadeIn){
        if(fadeIn){
            CanvasGroupFade(0, 1, 0.5f, startGameObject);
        }else{
            CanvasGroupFade(1, 0, 0.5f, startGameObject);
        }
    }

    public void FadeEndGameObject(bool fadeIn){
        if(fadeIn){
            CanvasGroupFade(0, 1, 0.5f, endGameObject);
        }else{
            CanvasGroupFade(1, 0, 0.5f, endGameObject);
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
        CanvasGroupFade(0, 1, 0.5f, counterObject);

        yield return new WaitForSeconds(1);
        counterText.text = "2";
        yield return new WaitForSeconds(1);
        counterText.text = "1";
        yield return new WaitForSeconds(1);
        counterText.text = "0";
        CanvasGroupFade(1, 0, 0.5f, counterObject);
        yield return new WaitForSeconds(1);
        ball.Launch();
    }

    public void CanvasGroupFade(float valorInicial, float valorFinal, float tiempoTotal, CanvasGroup canvasGroup){
        StartCoroutine(CanvasGroupFadeCoroutine(valorInicial, valorFinal, tiempoTotal, canvasGroup));
    }

    IEnumerator CanvasGroupFadeCoroutine(float valorInicial, float valorFinal, float tiempoTotal, CanvasGroup canvasGroup){
        float tiempoActual = 0;

        if(valorInicial == 1) canvasGroup.blocksRaycasts = false;

        do{
            tiempoActual += Time.deltaTime;

            // Debug.Log("Tiempo actual vale: " + tiempoActual + " con un delta time de: " + Time.deltaTime);
            // Debug.Log(string.Format("Tiempo actual vale: {0}, con un delta time de: {1}", tiempoActual, Time.deltaTime));
            // Debug.Log($"Tiempo actual vale: {tiempoActual}, con un delta time de: {Time.deltaTime}, y porcentaje de: {porcentaje}");

            float porcentaje = tiempoActual / tiempoTotal;
            canvasGroup.alpha = Mathf.Lerp(valorInicial, valorFinal, porcentaje);
            
            yield return null;
        }while(tiempoActual <= tiempoTotal);

        if(valorFinal == 1) canvasGroup.blocksRaycasts = true;

        // Debug.Log($"Ya acabamos");
    }
}
