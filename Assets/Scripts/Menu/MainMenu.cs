using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(string sceneName){
        GameManager.instance.ChangeScene(sceneName);
    }

    public void ExitGame(){
        GameManager.ExitGame();
    }
}
