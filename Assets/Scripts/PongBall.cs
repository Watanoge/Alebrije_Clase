using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public PongUI ui;

    public float speed = 30;

    public RectTransform rectTransform;
    public Rigidbody2D rb;

    Vector3 startingPosition;

    void Start()
    {
        startingPosition = rectTransform.localPosition;
        Launch();
    }

    public void Launch(){
        float x = 0;
        float y = 0;

        if(Random.Range(0, 100) <= 50){
            x = 1;
        }else{
            x = -1;
        }

        if(Random.Range(0, 100) <= 50){
            y = 1;
        }else{
            y = -1;
        }

        rb.velocity = new Vector2(x, y) * speed;
    }

    public void ResetPosition(){
        rb.velocity = new Vector2(0,0);
        rectTransform.localPosition = startingPosition;
        Invoke("Launch", 3);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Jugador Izquierda"){
            BounceFromPlayer(1);
        }else if(other.gameObject.name == "Jugador Derecha"){
            BounceFromPlayer(-1);
        }else if(other.gameObject.name == "Borde Superior"){
            BounceFromWall(-1);
        }else if(other.gameObject.name == "Borde Inferior"){
            BounceFromWall(1);
        }else if(other.gameObject.name == "Borde Izquierda"){
            ui.AddPointsToRight();
            ResetPosition();
        }else if(other.gameObject.name == "Borde Derecha"){
            ui.AddPointsToLeft();
            ResetPosition();
        }
    }

    public void BounceFromPlayer(float _direction){
        float verticalDirection = 0;
        if(rb.velocity.y < 0) verticalDirection = -1;
        else verticalDirection = 1;

        Vector2 direction = new Vector2(_direction, verticalDirection);

        rb.velocity = direction * speed;
    }

    public void BounceFromWall(float _direction){
        float horizontalDirection = 0;
        if(rb.velocity.x < 0) horizontalDirection = -1;
        else horizontalDirection = 1;

        Vector2 direction = new Vector2(horizontalDirection, _direction);

        rb.velocity = direction * speed;
    }
}
