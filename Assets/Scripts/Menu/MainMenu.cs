using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable] //Unity necesita esto para mostrarlo en el editor y hacerlo una clase "interactuable"
public class MinigameMenuObject {
    public string minigameDisplayName;
    public string minigameSceneName;
    public GameObject minigameSettings;
}

public class MainMenu : MonoBehaviour
{
    public float fadeTime = 0.1f;

    public TextMeshProUGUI gameTitle;

    public CanvasGroup gameContainer;

    public MinigameMenuObject[] minigameMenuObjects;

    public int currentGameIndex = 0;

    public bool doLoop;
    public GameObject lastGameButton, nextGameButton;

    void Awake(){
        currentGameIndex = 0;
        LoadGameDisplay();
    }

    public void ExitGame(){
        GameManager.ExitGame();
    }

    public void NextGame(){
        currentGameIndex++;

        if(doLoop){
            if(currentGameIndex >= minigameMenuObjects.Length){
                currentGameIndex = 0;
            }
        }

        StartCoroutine(DisplayGameCoroutine());
    }

    public void LastGame(){
        currentGameIndex--;

        if(doLoop){
            if(currentGameIndex < 0){
                currentGameIndex = minigameMenuObjects.Length - 1;
            }
        }
        StartCoroutine(DisplayGameCoroutine());
    }

    public void LoadGame(){
        GameManager.instance.ChangeScene(minigameMenuObjects[currentGameIndex].minigameSceneName);
    }

    public void LoadGameDisplay(){
        if(!doLoop){
            nextGameButton.SetActive(currentGameIndex < minigameMenuObjects.Length - 1);
            lastGameButton.SetActive(currentGameIndex > 0);
        }

        gameTitle.text = minigameMenuObjects[currentGameIndex].minigameDisplayName;
        for (int i = 0; i < minigameMenuObjects.Length; i++)
        {
            //Se puede resumir en:
            //minigameMenuObjects[i].minigameSettings.SetActive(i == currentGameIndex);

            if(i == currentGameIndex){
                minigameMenuObjects[i].minigameSettings.SetActive(true);
            }else{
                minigameMenuObjects[i].minigameSettings.SetActive(false);
            }
        }
    }

    public IEnumerator DisplayGameCoroutine(){
        GameManager.instance.CanvasGroupFade(1, 0, fadeTime, gameContainer);
        yield return new WaitForSeconds(fadeTime);
        LoadGameDisplay();
        GameManager.instance.CanvasGroupFade(0, 1, fadeTime, gameContainer);
    }
}
