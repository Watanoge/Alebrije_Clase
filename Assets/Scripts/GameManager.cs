using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static float HorizontalSpeed(float speed){
        return speed * (Screen.width / 1920f);
    }

    public static float VerticalSpeed(float speed){
        return speed * (Screen.height / 1080f);
    }
}
