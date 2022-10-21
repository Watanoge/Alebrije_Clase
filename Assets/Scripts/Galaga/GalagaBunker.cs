using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalagaBunker : BaseDamagable
{
    public Sprite[] spriteList;
    public Image renderer;

    public override void InitializeDamagable(){
        base.InitializeDamagable();
        UpdateSprite(0);
    }

    public override void ProcessCollision(){
        currentLife--;
        UpdateDisplay();
        if(currentLife <= 0) Kill();
    }

    public void UpdateDisplay(){
        int steps = Mathf.CeilToInt(maxLife/spriteList.Length * 1.0f);

        for (int i = 1; i <= spriteList.Length; i++)
        {
            bool isCurrentStep = currentLife >= maxLife - (steps * i);
            if(isCurrentStep){
                UpdateSprite(i-1);
                break;
            }
        }
    }

    public void UpdateSprite(int index){
        Sprite currentSprite = spriteList[index];
        renderer.sprite = currentSprite;
    }

    public override void Kill(){
        Debug.Log("Procesando Muerte");
        gameObject.SetActive(false);
    }
}