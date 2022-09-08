using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayer : BasePlayer
{
    public override void MoveDirection(Direction direction){
        Debug.Log("Procesando movimiento Dese Pong");
    }

    public override void ProcessCollision(){
        Debug.Log("Procesando Colisión Dese Pong");
    }
}
