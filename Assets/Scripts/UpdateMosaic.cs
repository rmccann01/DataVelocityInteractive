using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMosaic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] mosaics;
    public static int level = 0;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    public void UpdateImage(int balls)
    {
        spriteRenderer.sprite = mosaics[level+balls];
    }

    public void ResetImage()
    {
        level += 10;   
        spriteRenderer.sprite = mosaics[0];
        
    }
}
