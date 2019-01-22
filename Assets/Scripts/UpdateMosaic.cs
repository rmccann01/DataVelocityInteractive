using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMosaic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] mosaics;
    // Update is called once per frame
    public void UpdateImage(int balls)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = mosaics[balls];
    }

    public void ResetImage()
    {
        spriteRenderer.sprite = mosaics[0];
    }
}
