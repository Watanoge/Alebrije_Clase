using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayer : BasePlayer
{
    [Header("Pong")]
    public RectTransform rectTransform;
    public Rigidbody2D rigidBody;

    public bool hasBall, insideUpperLimit, insideLowerLimit;

    public override void MoveDirection(Direction direction){
        switch (direction)
        {
            case Direction.Up:
                if(insideUpperLimit){
                    rigidBody.MovePosition(rigidBody.position + (Vector2.up * GameManager.VerticalSpeed(maxSpeed) * Time.deltaTime));
                    // rectTransform.localPosition += Vector2.up * maxSpeed * Time.deltaTime;
                }
                break;
            case Direction.Down:
                if(insideLowerLimit){
                    rigidBody.MovePosition(rigidBody.position - (Vector2.up * GameManager.VerticalSpeed(maxSpeed) * Time.deltaTime));
                    // rectTransform.localPosition -= Vector2.up * maxSpeed * Time.deltaTime;
                }
                break;
            default:
                Debug.Log("Esto no se puede");
                break;
        }
    }

    public override void Shoot(){
        if(hasBall){
            Debug.Log("Shoot Ball");
        }
    }

    public override void ProcessCollision(){
        Debug.Log("Procesando Colisión Dese Pong");
    }
}
