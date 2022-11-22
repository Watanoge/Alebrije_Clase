using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaEnemyRow : MonoBehaviour
{
    public GalagaEnemy[] enemies;

    #region debug
    public KeyCode reset;
    
    void Update(){
        if (Input.GetKeyDown(reset)) //Disparamos
        {
            ResetEnemies();
        }
    }
    #endregion

    public void ResetEnemies(){
        foreach (GalagaEnemy enemy in enemies)
        {
            enemy.InitializeDamagable();
        }
    }
}
