using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CanvasGroup fadeImage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;

        ChangeScene("MainMenu");
    }

    public static float HorizontalSpeed(float speed){
        return speed * (Screen.width / 1920f);
    }

    public static float VerticalSpeed(float speed){
        return speed * (Screen.height / 1080f);
    }

    public void ChangeScene(string sceneName){
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }

    IEnumerator ChangeSceneCoroutine(string sceneName){
        CanvasGroupFade(0, 1, 0.5f, fadeImage);
        yield return new WaitForSeconds(1);
        CustomSceneManager.ChangeScene(sceneName);
        CanvasGroupFade(1, 0, 0.5f, fadeImage);
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

    public static void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
