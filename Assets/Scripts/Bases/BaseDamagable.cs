using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamagable : MonoBehaviour
{
    public string[] validTags;
    public int maxLife;
    [HideInInspector] public int currentLife;

    private void Start()
    {
        InitializeDamagable();
    }

    public virtual void InitializeDamagable(){
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
    }
}
