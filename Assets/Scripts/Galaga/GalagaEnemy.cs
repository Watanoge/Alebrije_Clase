using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaEnemy : BaseDamagable
{
    public int score;
    
    public override void Kill(){
        base.Kill();
        Debug.Log("Procesando Muerte Enemigo");
    }
}
