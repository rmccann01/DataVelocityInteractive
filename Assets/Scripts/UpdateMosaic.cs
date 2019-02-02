using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMosaic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] mosaics;
    public static int level = 0;
    //Initialize spriteRenderer of Image output
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //Display proper image based on data caught
    public void UpdateImage(int balls)
    {
        spriteRenderer.sprite = mosaics[(level*10)+balls];
    }
    //Reset image at end of game
    public void ResetImage()
    {
        level++;
        if (level == 5)
        {
            level = 0;
        }   
        spriteRenderer.sprite = mosaics[0];
        
    }
    //Make image black for new Level
    public void ClearImage()
    {
        spriteRenderer.sprite = mosaics[0];
    }
}
