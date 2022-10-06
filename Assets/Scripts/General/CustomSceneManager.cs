using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
