using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDamagable : MonoBehaviour
{
    public string[] validTags;
    public int maxLife;
    [HideInInspector] public int currentLife;

    public BoxCollider2D collider;
    public Image renderer;

    private void Start()
    {
        InitializeDamagable();
    }

    public virtual void InitializeDamagable(){
        ToggleElement(true);
        currentLife = maxLife;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bool canBeDamaged = false;
        foreach (string tag in validTags)
        {
            canBeDamaged = other.gameObject.CompareTag(tag);
            if(canBeDamaged) break;
        }
        
        if(canBeDamaged) ProcessCollision();
    }

    public virtual void ProcessCollision(){
        currentLife--;
        if(currentLife <= 0) Kill();
    }

    public virtual void Kill(){
        Debug.Log("Procesando Muerte");
        ToggleElement(false);
    }

    public virtual void ToggleElement(bool show){
        Debug.Log("Toggleado Visuales y Colisiones");
        // a = b = c = 10;

        // a = 10;
        // b = 10;
        // c = 10;

        // int a = 10;
        // algo.texto = a++; -> texto "10"
        // algo.texto = ++a; -> texto "12"

        // collider.enabled = show;
        // renderer.enabled = show;

        collider.enabled = renderer.enabled = show;
    }
}
