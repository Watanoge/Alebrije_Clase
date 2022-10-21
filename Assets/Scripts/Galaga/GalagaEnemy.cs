using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaEnemy : BaseDamagable
{
    public override void Kill(){
        gameObject.SetActive(false);
    }
}
