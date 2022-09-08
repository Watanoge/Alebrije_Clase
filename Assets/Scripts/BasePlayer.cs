using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right }

public class BasePlayer : MonoBehaviour
{
    public bool canShoot, //¿puede disparar?
        detectCollisions, //¿puede detectar colisiones?
        horizontalMovement, //¿puede moverse horizontalmente?
        verticalMovement; //¿puede moverse verticalmente?

    public float maxSpeed,  //Velocidad máxima
        currentSpeed; //Velocidad Actual
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && verticalMovement) //Mover Arriba
        {
            MoveDirection(Direction.Up);
        }

        if (Input.GetKeyDown(KeyCode.S) && verticalMovement) //Mover Abajo
        {
            MoveDirection(Direction.Down);
        }

        if (Input.GetKeyDown(KeyCode.A) && horizontalMovement) //Mover izquierda
        {
            MoveDirection(Direction.Left);
        }

        if (Input.GetKeyDown(KeyCode.D) && horizontalMovement) //Mover Derecha
        {
            MoveDirection(Direction.Right);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot) //Disparamos
        {
            Shoot();
        }
    }

    public virtual void MoveDirection(Direction direction){
        Debug.Log("Moving!");
    }

    public virtual void Shoot(){
        Debug.Log("Shooting!");
    }

    void OnTriggerEnter(Collider other)
    {
        if(detectCollisions) ProcessCollision();
    }

    public virtual void ProcessCollision(){
        Debug.Log("Procesando Colisión");
    }
}
