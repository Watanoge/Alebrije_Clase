using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderResizer : MonoBehaviour
{
    void Start()
    {
        Resize();
    }

    public void Resize(){
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rectTransform = GetComponent<RectTransform>();

        float x = rectTransform.sizeDelta.x;
        float y = rectTransform.sizeDelta.y;

        collider.offset = new Vector2(0, y/2f);
        collider.size = new Vector2(x, y);
    }
}
