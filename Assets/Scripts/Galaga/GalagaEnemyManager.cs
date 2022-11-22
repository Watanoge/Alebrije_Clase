using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaEnemyManager : MonoBehaviour
{
    public Vector2 horizontalLimits;
    public Vector2 verticalLimits;
    RectTransform rectTransform;

    public float horizontalSpeed, verticalSpeed;
    
    Vector2 direction;
    bool canMove;

    void Start(){
        rectTransform = GetComponent<RectTransform>();
        StartMovement(Vector2.right);
    }

    public void StartMovement(Vector2 _direction){
        Debug.Log("Iniciando movimiento hacia " + _direction);
        direction = _direction;
        canMove = true;
    }

    private void FixedUpdate()
    {        
        rectTransform.anchoredPosition += direction * horizontalSpeed * Time.deltaTime;
        
        if(rectTransform.anchoredPosition.x < horizontalLimits.x){
            Vector2 pos = rectTransform.anchoredPosition;
            pos.x = horizontalLimits.x;
            rectTransform.anchoredPosition = pos;
            MoveDown();
            StartMovement(Vector2.right);
        }
        
        if(rectTransform.anchoredPosition.x > horizontalLimits.y){
            Vector2 pos = rectTransform.anchoredPosition;
            pos.x = horizontalLimits.y;
            rectTransform.anchoredPosition = pos;
            MoveDown();
            StartMovement(-Vector2.right);
        }
    }

    public void MoveDown(){
        rectTransform.anchoredPosition += new Vector2(0, -verticalSpeed);

        if(rectTransform.anchoredPosition.y <= verticalLimits.x){
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y = verticalLimits.y;
            rectTransform.anchoredPosition = pos;
        }
    }
}
