using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boli : MonoBehaviour
{
    public Sprite inicial;
    public Sprite final;
    bool fase = false;  

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

     void OnMouseDown(){
        if(fase)
        {
            spriteRenderer.sprite = inicial; 
        }
        else
        {
            spriteRenderer.sprite = final;             
        }
        fase = !fase;

    }
}
