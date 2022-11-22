using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaBunkerManager : MonoBehaviour
{
    public GalagaBunker[] bunkers;

    #region debug
    public KeyCode reset;
    
    void Update(){
        if (Input.GetKeyDown(reset)) //Disparamos
        {
            ResetBunkers();
        }
    }
    #endregion

    public void ResetBunkers(){
        // for (int i = 0; i < bunkers.Length; i++)
        // {
        //     GalagaBunker bunker = bunkers[i];
        // }


        foreach (GalagaBunker bunker in bunkers)
        {
            bunker.InitializeDamagable();
        }
    }
}
