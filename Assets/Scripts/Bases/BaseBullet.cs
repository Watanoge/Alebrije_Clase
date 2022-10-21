using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float maxSpeed;
    public bool destroyOnTouch = true;

    Vector2 direction;
    bool canMove;

    public void StartMovement(Vector2 _direction){
        Debug.Log("Iniciando movimiento hacia " + _direction);
        direction = _direction;
        canMove = true;
    }

    private void FixedUpdate()
    {
        if(canMove)
            rigidBody.MovePosition(rigidBody.position + (direction * GameManager.OverallSpeed(maxSpeed) * Time.deltaTime));
    }

    public virtual void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(destroyOnTouch) DestroyBullet();
    }
}
