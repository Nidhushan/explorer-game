using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public Sprite OriginalSprite;
    public Sprite LitSprite;

    private SpriteRenderer spriteRenderer;

    public void SetLit(bool lit)
    {
        if (lit)
        {
            spriteRenderer.sprite = LitSprite;
        }
        else
        {
            spriteRenderer.sprite = OriginalSprite;
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OriginalSprite = spriteRenderer.sprite;
    }
}
