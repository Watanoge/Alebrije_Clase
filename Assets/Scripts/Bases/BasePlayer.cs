using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right }

public class BasePlayer : MonoBehaviour
{
    [Header("Controles")]
    public KeyCode movementUp;
    public KeyCode movementDown, movementLeft, movementRight, shoot;

    [Header("Configuración")]
    public bool canShoot; //¿puede disparar?
    
    public bool detectCollisions, //¿puede detectar colisiones?
        horizontalMovement, //¿puede moverse horizontalmente?
        verticalMovement; //¿puede moverse verticalmente?

    [Header("Variables")]
    public float maxSpeed;  //Velocidad máxima
    public float currentSpeed; //Velocidad Actual
        
    void FixedUpdate()
    {
        if (Input.GetKey(movementUp) && verticalMovement) //Mover Arriba
        {
            MoveDirection(Direction.Up);
        }

        if (Input.GetKey(movementDown) && verticalMovement) //Mover Abajo
        {
            MoveDirection(Direction.Down);
        }

        if (Input.GetKey(movementLeft) && horizontalMovement) //Mover izquierda
        {
            MoveDirection(Direction.Left);
        }

        if (Input.GetKey(movementRight) && horizontalMovement) //Mover Derecha
        {
            MoveDirection(Direction.Right);
        }
    }

    void Update(){
        if (Input.GetKeyDown(shoot) && canShoot) //Disparamos
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
